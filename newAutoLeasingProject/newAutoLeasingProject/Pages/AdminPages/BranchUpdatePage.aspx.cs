using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages
{
    public partial class BranchUpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // BranchID'yi QueryString'den al
                string branchID = Request.QueryString["BranchID"];
                if (!string.IsNullOrEmpty(branchID))
                {
                    LoadBranchDetails(branchID);
                    LoadEmployees(branchID);
                }
            }
        }

        private void LoadBranchDetails(string branchID)
        {
            try
            {
                SqlConnectionClass.CheckConnection();

                // Branch bilgilerini çekmek için sorgu
                SqlCommand command = new SqlCommand("SELECT * FROM Branch WHERE BranchID = @BranchID", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@BranchID", branchID);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    NameTxt.Text = dr["Name"].ToString();
                    CityTxt.Text = dr["City"].ToString();
                    ProvinceTxt.Text = dr["Province"].ToString();
                    CountryTxt.Text = dr["Country"].ToString();
                    AddressTxt.Text = dr["StreetAddress"].ToString();
                    PhoneTxt.Text = dr["Phone"].ToString();
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }

        private void LoadEmployees(string branchID)
        {
            try
            {
                SqlConnectionClass.CheckConnection();

                // Çalışan bilgilerini çekmek için sorgu
                SqlCommand command = new SqlCommand("SELECT EmployeeID, FirstName, LastName, Position, PhoneNumber FROM Employee WHERE BranchID = @BranchID", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@BranchID", branchID);

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                EmployeeGridView.DataSource = dt;
                EmployeeGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }

        protected void BranchInfoUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string branchID = Request.QueryString["BranchID"];

                SqlConnectionClass.CheckConnection();

                // Güncelleme sorgusu
                SqlCommand command = new SqlCommand(
                    "UPDATE Branch SET Name = @Name, City = @City, Province = @Province, Country = @Country, StreetAddress = @StreetAddress, Phone = @Phone WHERE BranchID = @BranchID",
                    SqlConnectionClass.connection
                );

                command.Parameters.AddWithValue("@BranchID", branchID);
                command.Parameters.AddWithValue("@Name", NameTxt.Text);
                command.Parameters.AddWithValue("@City", CityTxt.Text);
                command.Parameters.AddWithValue("@Province", ProvinceTxt.Text);
                command.Parameters.AddWithValue("@Country", CountryTxt.Text);
                command.Parameters.AddWithValue("@StreetAddress", AddressTxt.Text);
                command.Parameters.AddWithValue("@Phone", PhoneTxt.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Branch updated successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Branch not found.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }
    }
}