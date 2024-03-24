using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LastError"]!=null)
                {
                    Exception lastError = (Exception)Session["LastError"];
                    ErrorMessageText(lastError);
                    // Clear the session after retrieving the error
                    Session.Remove("LastError");
                }
            }

        }
        public void ErrorMessageText(Exception ex)
        {
            if (ex != null) {
            errorText.Text = ex.Message;
                errorTextDesc.Text = ex.ToString();
            }
        }
    }
}