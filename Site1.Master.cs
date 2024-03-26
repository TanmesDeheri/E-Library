using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string role = "";
            if (Session["role"]!=null)
                //Most of the Time when the page loads the session variable is null,hence gives null reference Exception,So handle this exception 
            role = Session["role"].ToString();
            try
            {
                if (role=="member")
                {
                    SignUp.Visible = false;
                    UserLogin.Visible = false;
                    LogOut.Visible = true;
                    userNameButton.Visible = true;
                    userNameButton.Text = "Hello," + Session["fullname"];
                    btnAuthorManagement.Visible = false;
                    btnPublisherManagement.Visible = false;
                    btnBookInventory.Visible = false;
                    btnBookIssuing.Visible = false;
                    btnBookManagement.Visible = false;
                }
                else if (role=="admin")
                {
                    SignUp.Visible = false;
                    UserLogin.Visible = false;
                    btnAdminLogin.Visible = false;
                    LogOut.Visible = true;
                    userNameButton.Visible = true;
                    userNameButton.Text = "Hello Admin";
                    btnAuthorManagement.Visible = true;
                    btnPublisherManagement.Visible = true;
                    btnBookInventory.Visible = true;
                    btnBookIssuing.Visible = true;
                    btnBookManagement.Visible = true;
                }
                else
                {
                    SignUp.Visible = true;
                    UserLogin.Visible = true;
                    LogOut.Visible = false;
                    userNameButton.Visible = false;
                    btnAuthorManagement.Visible = false;
                    btnPublisherManagement.Visible = false;
                    btnBookInventory.Visible = false;
                    btnBookIssuing.Visible = false;
                    btnBookManagement.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        protected void RedirectToAdminLogin(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }
        protected void RedirectToAuthorManagement(object sender, EventArgs e)
        {
            Response.Redirect("adminAuthorManagement.aspx");
        }
        protected void RedirectToPublisherManagement(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagement.aspx");
        }
        protected void RedirectToBookInventory(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventoryPage.aspx");
        }
        protected void RedirectToBookIssuing(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuePage.aspx");
        }
        protected void RedirectBookManagement(object sender, EventArgs e)
        {
            Response.Redirect("admiwnAuthorManagement.aspx");
        }
        protected void RedirectToLogin(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }
        protected void RedirectToSignUp(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }
        protected void LoggingOut(object sender, EventArgs e)
        {
            Session.Remove("username");
            Session.Remove("fullname");
            Session.Remove("status");
            Session.Remove("role");
            Response.Redirect("HomePage.aspx");
        }
    }
}