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
    public partial class AdminLoginPage : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CheckCredentials(object sender, EventArgs e)
        {
            if (adminLoginID.Text.Trim() != "" && adminLoginPassword.Text.Trim() != "")
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
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ADMIN_LOGIN_TABLE WHERE USERNAME='" + adminLoginID.Text.Trim() + "'AND PASSWORD='" + adminLoginPassword.Text.Trim() + "'", sqlConnection);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Session["username"] = dataReader.GetValue(0).ToString();
                            Session["fullname"] = dataReader.GetValue(2).ToString();
                            Session["role"] = "admin";
                        }
                        Response.Redirect("HomePage.aspx", false);
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
    }
}