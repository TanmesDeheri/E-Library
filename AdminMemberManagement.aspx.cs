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
    public partial class AdminMemberManagement : System.Web.UI.Page
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            gridView.DataBind();
            FullName.ReadOnly = true;
            DOB.ReadOnly = true;
            ContactNumber.ReadOnly = true;
            EmailId.ReadOnly = true;
            StateName.ReadOnly = true;
            CityName.ReadOnly = true;
            PinCode.ReadOnly = true;
            Address.ReadOnly = true;
            AccountStatus.ReadOnly = true;

        }
        protected void SearchMemberDetails(object sender, EventArgs args)
        {
            try
            {

                if (MemberIdTextBox.Text.Trim() != "")
                {
                    if (CheckMemberExists())
                    {
                        FillMemberDeatails();
                    }
                    else
                    {
                        Response.Write("<script>alert('Member Does not exist')</script>");

                    }
                }
                else
                {
                    Response.Write("<script>alert('Member Id is Empty')</script>");
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        bool CheckMemberExists()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MEMBER_MASTER_TABLE WHERE MEMBER_ID=@memberId;", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@memberId", MemberIdTextBox.Text.Trim());
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
        void FillMemberDeatails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MEMBER_MASTER_TABLE WHERE MEMBER_ID=@memberId", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@memberId", MemberIdTextBox.Text.Trim());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        FullName.Text = sqlDataReader.GetString(0).ToString();
                        DOB.Text = sqlDataReader.GetFieldValue<DateTime>(1).ToString().Substring(0, 10);
                        ContactNumber.Text = sqlDataReader.GetFieldValue<long>(2).ToString();
                        EmailId.Text = sqlDataReader.GetString(3).ToString();
                        StateName.Text = sqlDataReader.GetString(4).ToString();
                        CityName.Text = sqlDataReader.GetString(5).ToString();
                        PinCode.Text = sqlDataReader.GetFieldValue<Int32>(6).ToString();
                        Address.Text = sqlDataReader.GetString(7).ToString();
                        AccountStatus.Text = sqlDataReader.GetString(10).ToString();
                    }
                }
            }
        }
        protected void ActiveAccountStatus(object sender, EventArgs e)
        {
            try
            {
                if (MemberIdTextBox.Text.Trim() != "")
                {
                    if (CheckMemberExists())
                    {
                        ChangeAccountStatus("Active");
                        gridView.DataBind();
                        Response.Write("<script>alert('Account status changed.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('member Doesnt exist')</script>");

                    }

                }
                else
                {
                    Response.Write("<script>alert('Member Id is Empty')</script>");
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }

        }
        protected void PendingAccountStatus(object sender, EventArgs e)
        {
            try
            {
                if (MemberIdTextBox.Text.Trim() != "")
                {
                    if (CheckMemberExists())
                    {

                        ChangeAccountStatus("Pending");
                        gridView.DataBind();
                        Response.Write("<script>alert('Account status changed.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('member Doesnt exist')</script>");

                    }
                }
                else
                {
                    Response.Write("<script>alert('Member Id is Empty')</script>");
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }

        }
        protected void DeactivateAccountStatus(object sender, EventArgs e)
        {
            try
            {
                if (MemberIdTextBox.Text.Trim() != "")
                {
                    if (CheckMemberExists())
                    {

                        ChangeAccountStatus("Deactivate");
                        gridView.DataBind();
                        Response.Write("<script>alert('Account status changed.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('member Doesnt exist')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Member Id is Empty')</script>");
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }

        }
        protected void DeleteAuthorDetails(object sender, EventArgs e)
        {
            if (MemberIdTextBox.Text.Trim() != "")
            {
                if (CheckMemberExists())
                    DeleteMember();
                else
                    Response.Write("<script>alert('user Id Doesn't Exists')</script>");

            }
            else
            {
                Response.Write("<script>alert('user Id is Empty)</script>");
            }
        }
        void DeleteMember()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("DELETE MEMBER_MASTER_TABLE WHERE MEMBER_ID=@MemberId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@MemberId", MemberIdTextBox.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    gridView.DataBind();
                    Response.Write("<script>alert('Member Deleted Successfully')</script>");
                }

            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }

        void ChangeAccountStatus(string status)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE MEMBER_MASTER_TABLE SET ACCOUNT_STATUS=@accStats WHERE MEMBER_ID=@memberId;", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@accStats", status);
                sqlCommand.Parameters.AddWithValue("@memberId", MemberIdTextBox.Text.Trim());
                sqlCommand.ExecuteNonQuery();
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            FillMemberDeatails();
        }
    }
}