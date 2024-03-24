using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Data;

namespace ELibrary
{
    public partial class UserSignUp : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["connectionToDB"].ConnectionString;
        Dictionary<string, List<string>> stateCityMap = new Dictionary<string, List<string>>
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
            if (!IsPostBack)
            {
                PopulateStateDropdown();
            }
        }
        private void PopulateStateDropdown()
        {
            // Sample data of states and cities

            // Bind states to StateDropdown
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
        //SignUp Button Click Event
        protected void SignUp(object sender, EventArgs e)
        {
            if (userID.Text.Trim().Length != 0)
            {
                if (!checkMemberExists())
                {
                    UserSignUpMethod();
                }
                else
                {
                    Response.Write("<script>alert('Member id Exists')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member id is Empty')</script>");
            }
        }
        bool checkMemberExists()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT MEMBER_ID FROM MEMBER_MASTER_TABLE WHERE MEMBER_ID='" + userID.Text.Trim() + "';", conn);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["LastError"] = ex;
                Response.Redirect("ErrorMessage.aspx");
                return false;
            }
        }
        private void UserSignUpMethod()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strcon))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO MEMBER_MASTER_TABLE(FULL_NAME,DATE_OF_BIRTH,CONTACT_NUMBER,EMAIL,STATE_NAME,CITY,PINCODE,FULL_ADDRESS,MEMBER_ID,MEMBER_PASSWORD,ACCOUNT_STATUS) VALUES (@FULL_NAME,@DATE_OF_BIRTH,@CONTACT_NUMBER,@EMAIL,@STATE_NAME,@CITY,@PINCODE,@FULL_ADDRESS,@MEMBER_ID,@MEMBER_PASSWORD,@ACCOUNT_STATUS)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@FULL_NAME", userSignUpFullName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@DATE_OF_BIRTH", userSignUpDOB.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@CONTACT_NUMBER", userContactNumber.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@EMAIL", userEmailID.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@STATE_NAME", StateDropdown.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@CITY", CityDropdown.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@PINCODE", userPinCode.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@FULL_ADDRESS", userAddress.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@MEMBER_ID", userID.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@MEMBER_PASSWORD", memberPassword.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@ACCOUNT_STATUS", "pending");
                    sqlCommand.ExecuteNonQuery();
                };
                Response.Write("<script>alert('Sign Up Successful, Return to Home Page')</script>");
            }
            catch (Exception ex)
            {
                Session["LastError"] = ex;
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}