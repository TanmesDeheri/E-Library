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
    public partial class adminPublisherManagement : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            gridView.DataBind();

        }
        protected void AddPublisherDetails(object sender, EventArgs e)
        {
            if (PublisherID.Text.Trim() != "")
            {
                if (checkAuthorExists())
                    Response.Write("<script>alert('user Id Exists')</script>");
                else
                    AddPublisher();
            }
            else
            {
                Response.Write("<script>alert('user Id is Empty)</script>");
            }
        }
        protected void DeletePublisherDetails(object sender, EventArgs e)
        {
            if (PublisherID.Text.Trim() != "")
            {
                if (checkAuthorExists())
                    DeletePublisher();
                else
                    Response.Write("<script>alert('user Id Doesn't Exists')</script>");

            }
            else
            {
                Response.Write("<script>alert('user Id is Empty)</script>");
            }
        }
        protected void EditPublisherDetails(object sender, EventArgs e)
        {
            if (PublisherID.Text.Trim() != "")
            {
                if (checkAuthorExists())
                    EditPublisher();
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
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PUBLISHER_MASTER_TABLE WHERE PUBLISHER_ID=@publisherId;", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@publisherId", PublisherID.Text.Trim());
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

        void AddPublisher()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO PUBLISHER_MASTER_TABLE (PUBLISHER_ID,PUBLISHER_NAME) Values(@publisherId,@publisherName);", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@publisherId", PublisherID.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@publisherName", PublisherName.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    gridView.DataBind();
                    Response.Write("<script>alert('publisher Added Successfully')</script>");
                }

            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void DeletePublisher()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("DELETE PUBLISHER_MASTER_TABLE WHERE PUBLISHER_ID=@publisherId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@publisherId", PublisherID.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    gridView.DataBind();
                    Response.Write("<script>alert('Publisher Deleted Successfully')</script>");
                }

            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void EditPublisher()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE PUBLISHER_MASTER_TABLE SET PUBLISHER_NAME=@publisherName WHERE PUBLISHER_ID=@publisherId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@publisherId", PublisherID.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@publisherName", PublisherName.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    gridView.DataBind();
                    Response.Write("<script>alert('Publisher Edited Successfully')</script>");
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