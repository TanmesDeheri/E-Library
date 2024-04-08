using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        static string globalFilePath;
        static string globalActualStocks, globalCurrentStocks, globalIssuedBooks;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAuthorDropdownList();
                FillPublisherDropdownList();
                FillLanguageList();
            }
            gridView.DataBind();
            IssuedBooks.ReadOnly = true;
            CurrentStock.ReadOnly = true;
        }
        //Dropdown List Code  Blocks 
        void FillAuthorDropdownList()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT AUTHOR_NAME FROM AUTHOR_MASTER_TABLE;", sqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    AuthorDropdownList.DataSource = dataTable;
                    AuthorDropdownList.DataValueField = "AUTHOR_NAME";
                    AuthorDropdownList.DataBind();
                    ListItem listItem = new ListItem("Select", "");
                    AuthorDropdownList.Items.Insert(0, listItem);
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void FillPublisherDropdownList()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT PUBLISHER_NAME FROM PUBLISHER_MASTER_TABLE;", sqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    PublisherDropdownList.DataSource = dataTable;
                    PublisherDropdownList.DataValueField = "PUBLISHER_NAME";
                    PublisherDropdownList.DataBind();
                    ListItem listItem = new ListItem("Select", "");
                    PublisherDropdownList.Items.Insert(0, listItem);
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void FillLanguageList()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT LanguageName FROM Language;", sqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Language.DataSource = dataTable;
                    Language.DataTextField = "LanguageName";
                    Language.DataValueField = "LanguageName";
                    Language.DataBind();
                    ListItem listItem = new ListItem("Select", "");
                    Language.Items.Insert(0, listItem);
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }

        //Book Existence
        bool CheckBookExists()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM BOOK_MASTER_TABLE WHERE Book_ID=@bookId OR BOOK_NAME=@bookName;", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@bookId", bookId.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@bookName", BookName.Text.Trim());
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
                Response.Redirect("ErrorPage.aspx", false);
            }
            return false;
        }

        //Handles Multiple Button Events
        protected void HandleBookData(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                if (button != null)
                {
                    if (button == AddBook)
                    {
                        if (CheckBookExists())
                        {
                            Response.Write("<script>alert('Book Id Exists.');</script>");
                        }
                        else
                        {
                            AddBookDetails();
                        }
                    }
                    else if (button == UpdateBook)
                    {
                        if (CheckBookExists())
                        {
                            UpdateBookDetails();
                        }
                        else
                        {
                            Response.Write("<script>alert('Book Id Doesn't Exists.');</script>");
                        }
                    }
                    else if (button == DeleteBook)
                    {
                        if (CheckBookExists())
                        {
                            DeleteBookDetails();
                        }
                        else
                        {
                            Response.Write("<script>alert('Book Id doesn't Exists.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        //Add,Update,Delete Book Code Blocks
        void AddBookDetails()
        {
            string genres = "";
            foreach (int i in Genre.GetSelectedIndices())
            {
                genres = genres + Genre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);
            //The below code is for File upload in the book inventory folder
            string filepath = "~/BookInventory/book-stack_3389081";
            string filename = Path.GetFileName(fileupload.PostedFile.FileName);
            fileupload.SaveAs(Server.MapPath("BookInventory/" + filename));
            filepath = "~/BookInventory/" + filename;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO [OnlineLibraryManagementDB].[dbo].[BOOK_MASTER_TABLE]
                ([BOOK_ID], [BOOK_NAME], [GENRE], [AUTHOR_NAME], [PUBLISHER_NAME], [PUBLISH_DATE], [BOOK_LANGUAGE], [BOOK_EDITION], [NO_OF_PAGES], [BOOK_DESCRIPTION], [ACTUAL_STOCK], [CURRENT_STOCK], [BOOK_IMAGE_LINK])
                VALUES
                (@BOOK_ID, @BOOK_NAME, @GENRE, @AUTHOR_NAME, @PUBLISHER_NAME, @PUBLISH_DATE, @BOOK_LANGUAGE, @BOOK_EDITION, @NO_OF_PAGES, @BOOK_DESCRIPTION, @ACTUAL_STOCK, @CURRENT_STOCK, @BOOK_IMAGE_LINK)";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@BOOK_ID", bookId.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@BOOK_NAME", BookName.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@GENRE", genres);
                sqlCommand.Parameters.AddWithValue("@AUTHOR_NAME", AuthorDropdownList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@PUBLISHER_NAME", PublisherDropdownList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@PUBLISH_DATE", PublisherDate.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@BOOK_LANGUAGE", Language.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@BOOK_EDITION", BookEdition.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NO_OF_PAGES", Pages.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@BOOK_DESCRIPTION", BookDescription.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@ACTUAL_STOCK", ActualStock.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@CURRENT_STOCK", CurrentStock.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@BOOK_IMAGE_LINK", filepath);
                sqlCommand.ExecuteNonQuery();
                Response.Write("<script>alert('Book Added SuccessFully');</script>");
                gridView.DataBind();
            }
        }
        void UpdateBookDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //Checking The Stocks Value
                int actualStocks = Convert.ToInt32(ActualStock.Text.Trim());
                int currentStock = Convert.ToInt32(CurrentStock.Text.Trim());
                if (actualStocks == Convert.ToInt32(globalActualStocks))
                {
                    //No Changes are Done in The Actual stocks
                }
                else
                {
                    //checks whether the new Actual stock is greater than previous issued books during the query
                    if (actualStocks < Convert.ToInt32(globalIssuedBooks))
                    {
                        Response.Write("<script>alert('Actual Stocks Cant be less than issued books')</script>");
                    }
                    else
                    {
                        currentStock = actualStocks - Convert.ToInt32(globalIssuedBooks);
                        CurrentStock.Text=currentStock.ToString();
                    }
                }

                //storing Genres Selection
                string genres = "";
                foreach (int i in Genre.GetSelectedIndices())
                {
                    genres = genres + Genre.Items[i] + ",";
                }
                _ = genres.Remove(genres.Length - 1);
                string sql = "UPDATE [OnlineLibraryManagementDB].[dbo].[BOOK_MASTER_TABLE]\r\n    SET \r\n        [BOOK_NAME] = @NewBookName,\r\n        [GENRE] = @NewGenre,\r\n        [AUTHOR_NAME] = @NewAuthorName,\r\n        [PUBLISHER_NAME] = @NewPublisherName,\r\n        [PUBLISH_DATE] = @NewPublishDate,\r\n        [BOOK_LANGUAGE] = @NewBookLanguage,\r\n        [BOOK_EDITION] = @NewBookEdition,\r\n        [NO_OF_PAGES] = @NewNumberOfPages,\r\n        [BOOK_DESCRIPTION] = @NewBookDescription,\r\n        [ACTUAL_STOCK] = @NewActualStock,\r\n        [CURRENT_STOCK] = @NewCurrentStock,\r\n        [BOOK_IMAGE_LINK] = @NewBookImageLink\r\n    WHERE\r\n        [BOOK_ID] = @BookID;";
                string filePath = "~/BookInventory/";
                string fileName = Path.GetFileName(fileupload.PostedFile.FileName);
                //check whether the file is empty or not
                if (fileName == "" || fileName == null)
                {
                    filePath = globalFilePath;
                }
                else
                {
                    fileupload.SaveAs(Server.MapPath("BooKInventory/" + fileName));
                    filePath = "~/BookInventory/" + fileName;
                }
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@bookId", bookId.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewBookName", BookName.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewGenre", genres);
                sqlCommand.Parameters.AddWithValue("@NewAuthorName", AuthorDropdownList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@NewPublisherName", PublisherDropdownList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@NewPublishDate", PublisherDate.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewBookLanguage", Language.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@NewBookEdition", BookEdition.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewNumberOfPages", Pages.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewBookDescription", BookDescription.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewCurrentStock", CurrentStock.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewActualStock", ActualStock.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@NewBOOK_IMAGE_LINK", filePath);
                sqlCommand.ExecuteNonQuery();
            }
            gridView.DataBind();
            Response.Write("<script>alert('Book Status Updated')</script>");
        }
        void DeleteBookDetails()
        {
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                string sql = "DELETE TABLE BOOK_MASTER_TABLE WHERE BOOK_ID=@bookId";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql,sqlConnection);
                sqlCommand.Parameters.AddWithValue("@bookId",bookId.Text.Trim());
                sqlCommand.ExecuteNonQuery();
            }
            Response.Write("<script>alert('Book Details Deleted Successfully');</script>");
            gridView.DataBind();
        }
        //Query Book Code Block
        protected void QueryBookDetails(object sender, EventArgs e)
        {
            try
            {
                if (CheckBookExists())
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        string sql = "SELECT * FROM BOOK_MASTER_TABLE WHERE BOOK_ID=@bookId;";
                        SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@bookId", bookId.Text.Trim());
                        sqlConnection.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            BookName.Text = dt.Rows[0]["BOOK_NAME"].ToString();
                            Language.SelectedValue = dt.Rows[0]["BOOK_LANGUAGE"].ToString().Trim();
                            AuthorDropdownList.SelectedValue = dt.Rows[0]["AUTHOR_NAME"].ToString().Trim();
                            PublisherDate.Text = dt.Rows[0]["PUBLISH_DATE"].ToString().Trim().Substring(0, 10);
                            PublisherDropdownList.SelectedValue = dt.Rows[0]["PUBLISHER_NAME"].ToString().Trim();
                            string[] genre = dt.Rows[0]["GENRE"].ToString().Trim().Split(',');
                            Genre.ClearSelection();
                            for (int i = 0; i < genre.Length; i++)
                            {
                                for (int j = 0; j < Genre.Items.Count; j++)
                                {
                                    if (genre[i] == Genre.Items[j].ToString())
                                    {
                                        Genre.Items[j].Selected = true;
                                    }
                                }
                            }
                            Pages.Text = dt.Rows[0]["NO_OF_PAGES"].ToString();
                            ActualStock.Text = dt.Rows[0]["ACTUAL_STOCK"].ToString();
                            CurrentStock.Text = dt.Rows[0]["CURRENT_STOCK"].ToString();
                            IssuedBooks.Text = (Convert.ToInt32(dt.Rows[0]["ACTUAL_STOCK"].ToString()) - Convert.ToInt32(dt.Rows[0]["CURRENT_STOCK"].ToString())).ToString();
                            BookDescription.Text = dt.Rows[0]["BOOK_DESCRIPTION"].ToString();
                            BookEdition.Text = dt.Rows[0]["BOOK_EDITION"].ToString();

                            globalActualStocks = dt.Rows[0]["ACTUAL_STOCK"].ToString();
                            globalCurrentStocks = dt.Rows[0]["CURRENT_STOCK"].ToString();
                            globalIssuedBooks = (Convert.ToInt32(globalActualStocks) - Convert.ToInt32(globalCurrentStocks)).ToString();
                            globalFilePath = dt.Rows[0]["BOOK_IMAGE_LINK"].ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid Book Id');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Book ID Doesnt Exists');</script>");
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