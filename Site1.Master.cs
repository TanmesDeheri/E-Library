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
    }
}