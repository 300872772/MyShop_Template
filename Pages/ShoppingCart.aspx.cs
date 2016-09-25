using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Pages_ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Get Id of current logged in user and display items in cart

        string userId = User.Identity.GetUserId();
        GetPurchasesInCart(userId);
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

        // TreeView treeView = (TreeView)Master.FindControl("TreeView1");
        // treeView.Visible = false;
       // Panel panel = (Panel)Master.FindControl("pnlTree");
       // panel.Visible = false;
    }
    private void GetPurchasesInCart(string userId)
    {
        CartModel model = new CartModel();
        double subTotal = 0;

        //Generate HTML for each eliment in purchase list

        List<Cart> purchaseList = model.GetOrdersInCart(userId);
        CreateShoptable(purchaseList, out subTotal);

        //Add total to seb page
        double tax = subTotal * 0.21;
        double totalamount = subTotal + tax + 15;

        //display value on page 
        litTotal.Text = "$ " + subTotal;
        litTax.Text = "$ " + tax;
        litTotalamount.Text = "$ " + totalamount;



    }


    private void CreateShoptable(List<Cart> purchaseList, out double subTotal)
    {
        subTotal = new Double();
        ProductModel model = new ProductModel();

        foreach (Cart cart in purchaseList)
        {
            Product product = model.GetProduct(cart.ProductID);

            //Creae the image button
            ImageButton btnImage = new ImageButton {
                
                ImageUrl = string.Format("~/Img/Products/{0}", product.Image), 
                PostBackUrl = string.Format ("~/Pages/Product.aspx?id-{0}", product.Id)
            };

            //Create the delete link

            LinkButton lnkDelete = new LinkButton
            {

                PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?productId-{0}", cart.ID),
                Text = "Delete Items",
                ID = "del" + cart.ID,
                CssClass = "button4"
            };

            //Add an onClick event
            lnkDelete.Click +=  Delete_Items; 

           //Create the quantity dropdown list
            //Generate list with numbers from  1 to 20
            int[] amount = Enumerable.Range(1, 20).ToArray();
            DropDownList ddlAmount = new DropDownList{
            DataSource = amount,
            AppendDataBoundItems = true,
            AutoPostBack=true,
            ID = cart.ID.ToString()
            };

            ddlAmount.DataBind();
            ddlAmount.SelectedValue = cart.Amount.ToString();
            ddlAmount.SelectedIndexChanged +=ddlAmount_SelectedIndexChanged;

            //Create HTML table with tow rows
            Table table = new Table { CssClass = "cartTable" };
            TableRow a = new TableRow();
            TableRow b = new TableRow();

            //Create 6 cells for Row a
            TableCell a1 = new TableCell { RowSpan = 2, Width = 50};
            TableCell a2 = new TableCell {Text = string.Format("<h4>{0}</h4><br/>In Stock", 
            product.Name, "Item No: " + product.Id), HorizontalAlign = HorizontalAlign.Left, Width=350};
            TableCell a3 = new TableCell { Text = "Unit Price <hr/>"};
            TableCell a4 = new TableCell { Text = "Quantity <hr/>"};
            TableCell a5= new TableCell {Text = "Item Total <hr/>" };
            TableCell a6 = new TableCell { };


            //Create 6 cells for Row b
            TableCell b1 = new TableCell { };
            TableCell b2 = new TableCell {Text = "$ " + product.Price };
            TableCell b3 = new TableCell { };
            TableCell b4 = new TableCell {Text = "$ " + Math.Round
                (Convert.ToDouble((cart.Amount * product.Price)), 2)};
            TableCell b5 = new TableCell { };
            TableCell b6 = new TableCell { };

            //Set special controls

            a1.Controls.Add(btnImage);
            a6.Controls.Add(lnkDelete);
            b3.Controls.Add(ddlAmount);

            //Add cells to row

            a.Cells.Add(a1);
            a.Cells.Add(a2);
            a.Cells.Add(a3);
            a.Cells.Add(a4);
            a.Cells.Add(a5);
            a.Cells.Add(a6);

            b.Cells.Add(b1);
            b.Cells.Add(b2);
            b.Cells.Add(b3);
            b.Cells.Add(b4);
            b.Cells.Add(b5);
            b.Cells.Add(b6);

            //Add rows to table

            table.Rows.Add(a);
            table.Rows.Add(b);

            //Add table to pnlShoppingCart
            pnlShoppingCart.Controls.Add(table);

            //Add total amount of item in cart to tsubtotal

            subTotal += Convert.ToDouble((cart.Amount * product.Price));


        }

        //Add current user's shopping cart to user specific shopping value
        Session[User.Identity.GetUserId()] = purchaseList;
    }

    private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList selectedList = (DropDownList)sender;
        int quantity = Convert.ToInt32(selectedList.SelectedValue);
        int cartId = Convert.ToInt32(selectedList.ID);

        CartModel model = new CartModel();
        model.UpdateQuantity(cartId, quantity);

        Response.Redirect("~/Pages/ShoppingCart.aspx");
    }

    private void Delete_Items(object sender, EventArgs e)
    {
        LinkButton selectedLink = (LinkButton)sender;
        string link = selectedLink.ID.Replace("del", "");
        int cartID = Convert.ToInt32(link);

        CartModel model = new CartModel();
        model.DeletCart(cartID);

        Response.Redirect("~/Pages/ShoppingCart.aspx");
    }

}