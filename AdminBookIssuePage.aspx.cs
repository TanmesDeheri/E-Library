using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class AdminBookIssuePage : System.Web.UI.Page
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            memberName.ReadOnly = true;
            bookName.ReadOnly = true;
            gridView.DataBind();
        }
        void getNames()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryForBookName = "SELECT BOOK_NAME FROM BOOK_MASTER_TABLE WHERE BOOK_ID=@bookId AND ACTUAL_STOCK>0";
                string queryForMemberName = "SELECT FULL_NAME FROM MEMBER_MASTER_TABLE WHERE MEMBER_ID=@memberId";
                //Quering For Book Name
                SqlCommand sqlCommand = new SqlCommand(queryForBookName, conn);
                sqlCommand.Parameters.AddWithValue("@bookId", BookID.Text.Trim());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bookName.Text = dt.Rows[0]["BOOK_NAME"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Book Id Doesnt Exist');</script>");
                }
                //Querying For Book Id
                sqlCommand = new SqlCommand(queryForMemberName, conn);
                sqlCommand.Parameters.AddWithValue("@memberId", MemberIdTextBox.Text.Trim());
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    memberName.Text = dt.Rows[0]["FULL_NAME"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Member Id Doesnt Exist');</script>");
                }
            }
        }
        void IssueBookMethod()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BOOK_ISSUE_TABLE(MEMBER_ID,MEMBER_NAME,BOOK_ID,BOOK_NAME,ISSUE_DATE,DUE_DATE) VALUES (@memberId,@memberName,@bookId,@bookName,@issueDate,@dueDate)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@memberId", MemberIdTextBox.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@memberName", memberName.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@bookId", BookID.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@bookName", bookName.Text.Trim().Substring(0, 10));
                sqlCommand.Parameters.AddWithValue("@issueDate", issueDate.Text.Trim().Substring(0, 10));
                sqlCommand.Parameters.AddWithValue("@dueDate", returnDate.Text.Trim());
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand = new SqlCommand("UPDATE BOOK_MASTER_TABLE SET CURRENT_STOCK=CURRENT_STOCK-1;", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Response.Write("<script>alert('Book issued Successfully')</script>");
                gridView.DataBind();
            }
        }
        void ReturnBookMethod()
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM BOOK_ISSUE_TABLE WHERE BOOK_ID=@bookId AND MEMBER_ID=@memberId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@bookId",BookID.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@memberId",MemberIdTextBox.Text.Trim());
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand= new SqlCommand("UPDATE BOOK_MASTER_TABLE SET CURRENT_STOCK=CURRENT_STOCK+1 WHERE BOOK_ID=@bookId ", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@bookId", BookID.Text.Trim());
                sqlCommand.ExecuteNonQuery();
                Response.Write("<script>alert('Book Returend');</script>");
            }
            gridView.DataBind();
        }
        bool CheckMemberExists()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM MEMBER_MASTER_TABLE WHERE MEMBER_ID=@memberId";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@memberId", MemberIdTextBox.Text.Trim());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        bool CheckBookExists()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM BOOK_MASTER_TABLE WHERE BOOK_ID=@bookId AND CURRENT_STOCK>0";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@bookId", BookID.Text.Trim());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        bool CheckDuplicateRecords()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BOOK_ISSUE_TABLE WHERE BOOK_ID=@bookid AND MEMBER_ID=@memberId";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@bookid", BookID.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@memberId", MemberIdTextBox.Text.Trim());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0) { return true; }
                else { return false; }
            }
        }
        protected void DefaultersRecord(object sender,GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType==DataControlRowType.DataRow) { 
                DateTime dateTime = Convert.ToDateTime(e.Row.Cells[5].Text);
                DateTime today= DateTime.Today;
                    if(today>dateTime)
                    {
                        e.Row.BackColor=System.Drawing.Color.Red;
                    }
                }
            }
            catch(Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        protected void HandleButtonClickEvents(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                if (button != null)
                {
                    if (MemberIdTextBox.Text.Trim() != "" && BookID.Text.Trim().Length > 0)
                    {
                        if (button == QueryButton)
                        {
                            if (MemberIdTextBox.Text.Trim() != "" && BookID.Text.Trim() != "")
                            {
                                getNames();
                            }
                        }
                        else if (button == issueButton)
                        {
                            if (CheckBookExists() && CheckMemberExists())
                            {
                                if (CheckDuplicateRecords())
                                {
                                    Response.Write("<script>alert('This Record Already Exists');</script>");
                                }
                                else
                                {
                                    IssueBookMethod();
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Book Id/Member Id doesnt exist Doesnt Exist');</script>");
                            }
                        }
                        else if (button == returnButton)
                        {
                            if (CheckBookExists() && CheckMemberExists())
                            {
                                ReturnBookMethod();
                            }
                            else
                            {
                                Response.Write("<script>alert(' Record Doesnt Exists');</script>");
                            }
                            //Code for return 
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Field Value is Empty');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
                //exception code
            }

        }
    }
}