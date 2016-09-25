using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Pages_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

        // TreeView treeView = (TreeView)Master.FindControl("TreeView1");
        // treeView.Visible = false;
       // Panel panel = (Panel)Master.FindControl("pnlTree");
        //panel.Visible = false;
        
    }
    private void FillPage()
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductModel productModel = new ProductModel();
            Product product = productModel.GetProduct(id);

            lblPrice.Text = "Price Per Unit:<br/>$ " + product.Price;
            lblTitel.Text = product.Name;
            lblDescription.Text = product.Description;
            lblItemNr.Text = id.ToString();
            imgProduct.ImageUrl = "~/Img/Products/" + product.Image;

            int[] amount = Enumerable.Range(1, 20).ToArray();

            ddlAmount.DataSource = amount;
            ddlAmount.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clintId = Context.User.Identity.GetUserId();

            if (clintId != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int amount = Convert.ToInt32(ddlAmount.SelectedValue);
                Cart cart = new Cart
                {
                    Amount = amount,
                    ClientID = clintId,
                    DatePurchased = DateTime.Now,
                    IsInCart = true,
                    ProductID = id
                };

                CartModel cartModel = new CartModel();
                lblResult.Text = cartModel.InsertCart(cart);
            }
            else 
            {
                lblResult.Text = "Please Login to order items";
            }
        }
    }
}