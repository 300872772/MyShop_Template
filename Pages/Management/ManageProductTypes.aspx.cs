using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProductTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }
        }
    }
        protected void Page_PreRender(object sender, EventArgs e)
    {

       // TreeView treeView = (TreeView)Master.FindControl("TreeView1");
       // treeView.Visible = false;
      //  Panel panel = (Panel)Master.FindControl("pnlTree");
      //  panel.Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductTypeModel productTypeModel = new ProductTypeModel();
        ProductTypes1 productType1 = CreateProductType();

        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResults.Text = productTypeModel.UpdateProductType(id, productType1);

        }
        else
        {

            lblResults.Text = productTypeModel.InsertProductType(productType1);
        }
       


    }

    private void FillPage(int id)
    {
        ProductTypeModel productTypeModel = new ProductTypeModel();
        ProductTypes1 productTypes1 = productTypeModel.GetProductTypes1(id);


        txtName.Text = productTypes1.Name;


    }

    private ProductTypes1 CreateProductType()
    {
        ProductTypes1 p = new ProductTypes1();
        p.Name = txtName.Text;
        return p;
    }
}