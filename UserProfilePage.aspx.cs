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
    public partial class UserProfilePage : System.Web.UI.Page
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        readonly Dictionary<string, List<string>> stateCityMap = new Dictionary<string, List<string>>
           {
             {"California", new List<string>{"Los Angeles", "San Francisco", "San Diego"}},
             {"New York", new List<string>{"New York City", "Buffalo", "Albany"}},
             {"Texas", new List<string>{"Houston", "Dallas", "Austin"}},
             {"Florida", new List<string>{"Miami", "Orlando", "Tampa"}},
             {"Illinois", new List<string>{"Chicago", "Springfield", "Peoria"}},
             {"Pennsylvania", new List<string>{"Philadelphia", "Pittsburgh", "Harrisburg"}},
             {"Ohio", new List<string>{"Columbus", "Cleveland", "Cincinnati"}},
             {"Michigan", new List<string>{"Detroit", "Grand Rapids", "Lansing"}},
             {"Georgia", new List<string>{"Atlanta", "Savannah", "Augusta"}},
             {"North Carolina", new List<string>{"Charlotte", "Raleigh", "Greensboro"}}
           };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string username = "";
                if (Session["username"] != null)
                {
                    username = Session["username"].ToString();
                }
                if (username == "")
                {
                    Response.Write("<script>alert('Session Expired Please Login Again')</script>");
                    Response.Redirect("HomePage.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        PopulateStateAndCity();
                    }
                    {
                        FillDataInTheBlanks();
                    }
                    UserID.ReadOnly = true;
                    OldPassword.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void FillDataInTheBlanks()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MEMBER_MASTER_TABLE WHERE MEMBER_ID=@memberId";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@memberId", Session["username"]);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        userFullName.Text = dt.Rows[0]["FULL_NAME"].ToString();
                        ContactNumber.Text = dt.Rows[0]["CONTACT_NUMBER"].ToString();
                        EmailId.Text = dt.Rows[0]["EMAIL"].ToString();
                        PinCode.Text = dt.Rows[0]["PINCODE"].ToString();
                        FullAddress.Text = dt.Rows[0]["FULL_ADDRESS"].ToString();
                        UserID.Text = dt.Rows[0]["MEMBER_ID"].ToString();
                        OldPassword.Text = dt.Rows[0]["MEMBER_PASSWORD"].ToString();
                        DOB.Text = Convert.ToDateTime(dt.Rows[0]["DATE_OF_BIRTH"]).ToString("yyyy-MM-dd");
                        ChangeAccountStatus(dt.Rows[0]["ACCOUNT_STATUS"].ToString());
                    }
                    sqlCommand = new SqlCommand("SELECT * FROM BOOK_ISSUE_TABLE WHERE MEMBER_ID=@memberId;", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@memberId", Session["username"].ToString());
                    adapter = new SqlDataAdapter(sqlCommand);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gridView.DataSource = dt;
                        gridView.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session["lastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
        void PopulateStateAndCity()
        {
            foreach (var state in stateCityMap.Keys)
            {
                StateDropdown.Items.Add(new ListItem(state, state));
            }
        }
        protected void StateDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = StateDropdown.SelectedValue;
            PopulateCityDropdown(selectedState);
        }
        private void PopulateCityDropdown(string state)
        {
            CityDropdown.Items.Clear();

            if (stateCityMap.ContainsKey(state))
            {
                foreach (var city in stateCityMap[state])
                {
                    CityDropdown.Items.Add(new ListItem(city, city));
                }
            }
        }
        void ChangeAccountStatus(string accountStatus)
        {
            accountStatusLabel.Text = accountStatus;
            if (accountStatus != null)
            {
                if (accountStatus == "Active")
                    accountStatusLabel.Attributes.Add("CssClass", "badge rounded-pill bg-success");
                else if (accountStatus == "Pending")
                    accountStatusLabel.Attributes.Add("CssClass", "badge rounded-pill bg-warning");
                else if (accountStatus == "Deactivate")
                    accountStatusLabel.Attributes.Add("CssClass", "badge rounded-pill bg-danger");
                else
                    accountStatusLabel.Attributes.Add("CssClass", "badge rounded-pill bg-secondary");
            }
        }
        protected void DefaultersRecord(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dateTime = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dateTime)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
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