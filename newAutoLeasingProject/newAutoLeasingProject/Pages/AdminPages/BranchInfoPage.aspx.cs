using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class BranchInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verileri yükle
                LoadBranchData();
                // Filtreleme için gerekli DropDown'ları doldur
                LoadFilterData();
            }
        }

        // Şehir değiştiğinde ilçe dropdown'ını güncelle
        protected void CityDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = CityDropdown.SelectedValue;
            LoadProvincesForCity(selectedCity);
            LoadBranchesForCityAndProvince(selectedCity, null); // initially, no province selected
        }

        // İlçe değiştiğinde şube dropdown'ını güncelle
        protected void ProvinceDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = CityDropdown.SelectedValue;
            string selectedProvince = ProvinceDropdown.SelectedValue;
            LoadBranchesForCityAndProvince(selectedCity, selectedProvince);
        }

        // Şube verilerini yükleme
        private void LoadBranchData()
        {
            try
            {
                SqlConnectionClass.CheckConnection();
                string query = "SELECT * FROM Branch";
                SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Repeater2.DataSource = dt;
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        // Filtreleme verilerini yükleme (Dropdown'ları doldurma)
        private void LoadFilterData()
        {
            try
            {
                SqlConnectionClass.CheckConnection();

                SqlCommand command = new SqlCommand("SELECT DISTINCT City FROM Branch", SqlConnectionClass.connection);
                SqlDataReader reader = command.ExecuteReader();
                CityDropdown.DataSource = reader;
                CityDropdown.DataTextField = "City";
                CityDropdown.DataValueField = "City";
                CityDropdown.DataBind();
                CityDropdown.Items.Insert(0, new ListItem("Şehir Seçin", ""));

                reader.Close();

                command.CommandText = "SELECT DISTINCT Country FROM Branch";
                reader = command.ExecuteReader();
                CountryDropDown.DataSource = reader;
                CountryDropDown.DataTextField = "Country";
                CountryDropDown.DataValueField = "Country";
                CountryDropDown.DataBind();
                CountryDropDown.Items.Insert(0, new ListItem("Ülke Seçin", ""));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        // Şehir seçildiğinde ilgili ilçeleri yükle
        private void LoadProvincesForCity(string city)
        {
            try
            {
                SqlConnectionClass.CheckConnection();

                SqlCommand command = new SqlCommand("SELECT DISTINCT Province FROM Branch WHERE City = @City", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@City", city);
                SqlDataReader reader = command.ExecuteReader();

                ProvinceDropdown.DataSource = reader;
                ProvinceDropdown.DataTextField = "Province";
                ProvinceDropdown.DataValueField = "Province";
                ProvinceDropdown.DataBind();
                ProvinceDropdown.Items.Insert(0, new ListItem(" ", ""));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        // Şehir ve ilçe seçildiğinde şubeleri yükle
        private void LoadBranchesForCityAndProvince(string city, string province)
        {
            try
            {
                SqlConnectionClass.CheckConnection();

                string query = "SELECT * FROM Branch WHERE City = @City";
                if (!string.IsNullOrEmpty(province))
                {
                    query += " AND Province = @Province";
                }

                SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@City", city);
                if (!string.IsNullOrEmpty(province))
                {
                    command.Parameters.AddWithValue("@Province", province);
                }

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Repeater2.DataSource = dt;
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        // Filtreleme butonuna tıklama işlemi
        protected void FilterBtn_Click(object sender, EventArgs e)
        {
            string cityFilter = CityDropdown.SelectedValue.Trim();
            string provinceFilter = ProvinceDropdown.SelectedValue.Trim();
            string countryFilter = CountryDropDown.SelectedValue.Trim();

            try
            {
                SqlConnectionClass.CheckConnection();

                string query = "SELECT * FROM Branch WHERE City LIKE @City AND Province LIKE @Province AND Country LIKE @Country";
                SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@City", "%" + cityFilter + "%");
                command.Parameters.AddWithValue("@Province", "%" + provinceFilter + "%");
                command.Parameters.AddWithValue("@Country", "%" + countryFilter + "%");

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Repeater2.DataSource = dt;
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        // Temizle butonuna tıklama işlemi
        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            CityDropdown.SelectedIndex = 0;
            ProvinceDropdown.SelectedIndex = 0;
            CountryDropDown.SelectedIndex = 0;
            LoadBranchData();
        }

        // Şube silme işlemi
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string branchId = deleteButton.CommandArgument;

            try
            {
                SqlConnectionClass.CheckConnection();

                SqlCommand command = new SqlCommand("DELETE FROM Branch WHERE BranchId = @BranchId", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@BranchId", branchId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Branch deleted successfully.');", true);
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
            finally
            {
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }

            Response.Redirect(Request.RawUrl);
        }

        // Şube düzenleme işlemi
        protected void InfoButton_Click(object sender, EventArgs e)
        {
            string branchId = ((Button)sender).CommandArgument;
            Response.Redirect($"/Pages/AdminPages/BranchUpdatePage.aspx?BranchId={branchId}");
        }
    }
}