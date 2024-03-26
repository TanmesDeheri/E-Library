using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class UserLogin : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SignUpInvisible"] = true;
        }
        protected void CheckLoginCrendentials(object sender, EventArgs e)
        {

            if (memberLoginID.Text.Trim() != "" && MemberLoginPassword.Text.Trim() != "")
            {
                CheckFromDB();
            }
            else
            {
                Response.Write("<script>alert('Field entries are Empty')</script>");
            }
        }
        private void CheckFromDB()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strcon))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MEMBER_MASTER_TABLE WHERE MEMBER_ID='" + memberLoginID.Text.Trim() + "'AND MEMBER_PASSWORD='" + MemberLoginPassword.Text.Trim() + "'", sqlConnection);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Session["username"] = dataReader.GetValue(8).ToString();
                            Session["fullname"] = dataReader.GetValue(0).ToString();
                            Session["role"] = "member";
                            Session["status"] = dataReader.GetValue(10).ToString();
                        }
                            Response.Redirect("HomePage.aspx", false);//the argument false implies that the current page Execution should not be stopped
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong Crendentials')</script>");
                    }
                }
            }


            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void RedirectToSignUpPage(Object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }
    }
}