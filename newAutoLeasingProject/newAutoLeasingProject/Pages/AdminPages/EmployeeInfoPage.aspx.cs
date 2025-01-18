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
    public partial class EmployeeInfoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeData();

            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                SqlConnectionClass.CheckConnection();

                // Sorguya Branch tablosunu dahil ederek BranchName'i çekiyoruz
                string query = @"
            SELECT 
                Employee.EmployeeID, 
                Employee.FirstName, 
                Employee.LastName, 
                Employee.PhoneNumber, 
                Employee.Email, 
                Employee.Salary, 
                Employee.Position, 
                Employee.Status, 
                Branch.Name AS BranchName, -- BranchName yerine geçiyor
                Employee.BirthDate 
            FROM 
                Employee
            LEFT JOIN 
                Branch ON Employee.BranchID = Branch.BranchID"; // Branch tablosu ile bağlantı

                SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                EmployeeRepeater.DataSource = dt;
                EmployeeRepeater.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        protected void InfoBtn_Click(object sender, EventArgs e)
        {
            string EmployeeID = ((Button)sender).CommandArgument;
            Response.Redirect($"/Pages/AdminPages/EmployeeUpdatePage.aspx?EmployeeID={EmployeeID}");
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/Pages/AdminPages/EmployeeAddPage.aspx");

        }


        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string EmployeeID = deleteButton.CommandArgument;

            try
            {
                SqlConnectionClass.CheckConnection();

                SqlCommand command = new SqlCommand("DELETE FROM Employee WHERE EmployeeID = @EmployeeID", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Employee deleted successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Employee not found.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            // Filtre alanlarını temizle
            FirstNameTextBox.Text = string.Empty;
            StatusDropDown.SelectedIndex = 0; // Tümü seçeneğini seç

            // Tüm çalışan verilerini yeniden yükle
            LoadEmployeeData();
        }

        protected void FilterBtn_Click(object sender, EventArgs e)
        {
            string firstNameFilter = FirstNameTextBox.Text.Trim(); // Ad filtreleme
            string statusFilter = StatusDropDown.SelectedValue;   // Durum filtreleme

            try
            {
                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // SQL sorgusunu oluştur
                string query = @"
            SELECT 
                Employee.EmployeeID, 
                Employee.FirstName, 
                Employee.LastName, 
                Employee.PhoneNumber, 
                Employee.Email, 
                Employee.Salary, 
                Employee.Position, 
                Employee.Status, 
                Branch.Name AS BranchName, 
                Employee.BirthDate 
            FROM 
                Employee
            LEFT JOIN 
                Branch ON Employee.BranchID = Branch.BranchID
            WHERE 1=1";

                // Ad ve durum filtrelerine göre sorguyu genişlet
                if (!string.IsNullOrEmpty(firstNameFilter))
                    query += " AND Employee.FirstName LIKE @FirstName";

                if (!string.IsNullOrEmpty(statusFilter))
                    query += " AND Employee.Status = @Status";

                using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
                {
                    // Parametreleri ekle
                    if (!string.IsNullOrEmpty(firstNameFilter))
                        command.Parameters.AddWithValue("@FirstName", "%" + firstNameFilter + "%");

                    if (!string.IsNullOrEmpty(statusFilter))
                        command.Parameters.AddWithValue("@Status", statusFilter);

                    // Veriyi çek ve DataTable'a yükle
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Filtrelenmiş veriyi Repeater'a bağla
                    EmployeeRepeater.DataSource = dt;
                    EmployeeRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya mesaj göster
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                // Bağlantıyı kapat
                if (SqlConnectionClass.connection.State == ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }
    }
}