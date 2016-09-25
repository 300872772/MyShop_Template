using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;



public partial class Pages_Account_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

       // TreeView treeView = (TreeView)Master.FindControl("TreeView1");
       // treeView.Visible = false;
      //  Panel panel = (Panel)Master.FindControl("pnlTree");
       // panel.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        userStore.Context.Database.Connection.ConnectionString = 
            System.Configuration.ConfigurationManager.ConnectionStrings["ShopDBConnectionString"].ConnectionString;


        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore); 

        //Create new user and try to store in BD

        IdentityUser user = new IdentityUser();
        user.UserName = txtUserName.Text;

        if (txtPassword.Text == txtConfirmPassword.Text)
        {
            try
            {
                //Creat user database. Database will be createded/ expanded automatically
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    //save user information in UserInformation Tabel
                    UserInformation info = new UserInformation
                        {
                        Address = txtAddress.Text, 
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        PostCode = txtPostalCode.Text,
                        GUID = user.Id
                        };

                    UserInfoModel model = new UserInfoModel();
                    model.InsertUserInformation(info);

                    //Store user in DB.
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    //set to log in new user by Cookie.
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    //login the new user and redirect to homepage.
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Index.aspx");

                }
                else
                {
                    litStatus.Text = result.Errors.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                litStatus.Text = ex.ToString();
            }
        }
        else
        {
            litStatus.Text = "Passwaord Must Match";
        }
    }
  
}