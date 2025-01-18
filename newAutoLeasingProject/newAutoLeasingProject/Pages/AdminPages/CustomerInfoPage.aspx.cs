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
    public partial class CustomerInfoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // İlk yüklendiğinde tüm verileri getirebilirsiniz
                LoadCustomerData();
            }
        }

        // Filtreleme işlemi
        protected void FilterBtn_Click(object sender, EventArgs e)
        {
            string firstNameFilter = FirstNameTextBox.Text.Trim();

            try
            {
                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // SQL sorgusu oluşturuluyor
                string query = "SELECT * FROM Customer WHERE FirstName LIKE @FirstName";
                SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);

                // Filtreleme için parametre ekleniyor
                command.Parameters.AddWithValue("@FirstName", "%" + firstNameFilter + "%");

                // Veriyi al
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                // Verileri Repeater'a bağla
                CustomerRepeater.DataSource = dt;
                CustomerRepeater.DataBind();
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                // Bağlantıyı kapat
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        // Müşteri silme işlemi
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            // Get CustomerID from the button's CommandArgument
            Button deleteButton = (Button)sender;
            string customerID = deleteButton.CommandArgument;

            try
            {
                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // SQL DELETE komutunu oluştur
                SqlCommand command = new SqlCommand("DELETE FROM Customer WHERE CustomerID = @CustomerID", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Başarılı mesajı
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Customer deleted successfully.');", true);
                }
                else
                {
                    // Müşteri bulunamazsa mesaj
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Customer not found.');", true);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                // Bağlantıyı kapat
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }

            // Sayfayı yenileyerek güncellenmiş veriyi göster
            Response.Redirect(Request.RawUrl);
        }

        // Müşteri düzenleme işlemi
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            // Get CustomerID from the button's CommandArgument
            string customerID = ((Button)sender).CommandArgument;

            // Müşteri düzenleme sayfasına yönlendirme
            Response.Redirect($"/Pages/AdminPages/CustomerUpdatePage.aspx?CustomerID={customerID}");
        }

        // Sayfada tüm müşteri verilerini yükle
        private void LoadCustomerData()
        {
            try
            {
                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // SQL komutunu oluştur
                string query = "SELECT * FROM Customer";
                SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection);

                // Veriyi al
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                // Veriyi Repeater'a bağla
                CustomerRepeater.DataSource = dt;
                CustomerRepeater.DataBind();
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                // Bağlantıyı kapat
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }
    }
}
