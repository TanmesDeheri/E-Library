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
    public partial class adminAuthorManagement : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            gridView.DataBind();
        }
        protected void QueryAuthorDetails(object sender, EventArgs e)
        {
            if (AuthorID.Text.Trim() != "")
            {
                if (checkAuthorExists())
                    Response.Write("<script>alert('user Id Exists')</script>");
                else
                    AddAuthor();
            }
            else
            {
                Response.Write("<script>alert('user Id is Empty)</script>");
            }
        }
        protected void DeleteAuthorDetails(object sender, EventArgs e)
        {
            if (AuthorID.Text.Trim() != "")
            {
                if (checkAuthorExists())
                   DeleteAuthor();
                else
                    Response.Write("<script>alert('user Id Doesn't Exists')</script>");

            }
            else
            {
                Response.Write("<script>alert('user Id is Empty)</script>");
            }
        }
        protected void EdtiAuthorDetails(object sender, EventArgs e)
        {
            if (AuthorID.Text.Trim() != "")
            {
                if (checkAuthorExists())
                    EditAuthor();
                else
                    Response.Write("<script>alert('user Id Doesn't Exists')</script>");

            }
            else
            {
                Response.Write("<script>alert('user Id is Empty)</script>");
            }
        }
        bool checkAuthorExists()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM AUTHOR_MASTER_TABLE WHERE AUTHOR_ID=@authorId;", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@authorId",AuthorID.Text.Trim());
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
            return false;
        }

        void AddAuthor()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO AUTHOR_MASTER_TABLE (AUTHOR_ID,AUTHOR_NAME) VALUES(@authorId,@authorName);", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@authorId", AuthorID.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@authorName", AuthorName.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    gridView.DataBind();
                    Response.Write("<script>alert('Author Added Successfully')</script>");
                }

            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void DeleteAuthor()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("DELETE AUTHOR_MASTER_TABLE WHERE AUTHOR_ID=@authorId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@authorId", AuthorID.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    gridView.DataBind();
                    Response.Write("<script>alert('Author Deleted Successfully')</script>");
                }

            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void EditAuthor()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE AUTHOR_MASTER_TABLE SET AUTHOR_NAME=@authorName WHERE AUTHOR_ID=@authorId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@authorId", AuthorID.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@authorName", AuthorName.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    gridView.DataBind();
                    Response.Write("<script>alert('Author Edited Successfully')</script>");
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