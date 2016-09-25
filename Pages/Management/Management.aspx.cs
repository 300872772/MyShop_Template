using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

        // TreeView treeView = (TreeView)Master.FindControl("TreeView1");
        // treeView.Visible = false;
      //  Panel panel = (Panel)Master.FindControl("pnlTree");
      //  panel.Visible = false;
    }
    protected void sdsProducts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = grdProducts.Rows[e.NewEditIndex];
        int rowId = Convert.ToInt32(row.Cells[1].Text);
        Response.Redirect("~/Pages/Management/ManageProduct.aspx?id=" + rowId);
    }



    protected void sdsProductsType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = grdProductsTypes.Rows[e.NewEditIndex];
        int rowId = Convert.ToInt32(row.Cells[1].Text);
        Response.Redirect("~/Pages/Management/ManageProductTypes.aspx?id=" + rowId);
    }
}