using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Pages_Account_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        


    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

        // TreeView treeView = (TreeView)Master.FindControl("TreeView1");
       //  treeView.Visible = false;
       // Panel panel = (Panel)Master.FindControl("pnlTree");
       // panel.Visible = false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        userStore.Context.Database.Connection.ConnectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["ShopDBConnectionString"].ConnectionString;


        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(txtUserName.Text, txtPassword.Text);

        if (user != null)
        {
            // call OWIN functionality 
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            //sign in user
            authenticationManager.SignIn(new AuthenticationProperties
            { IsPersistent = false}, userIdentity);

            //redirect user to homepage
            Response.Redirect("~/Index.aspx");
        }
        else 
        {
            ltlStatus.Text = "invalid Username or password";


        }
    }
}