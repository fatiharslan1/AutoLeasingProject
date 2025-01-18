using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class CustomerUpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Query string'den müşteri ID'sini al
                string customerId = Request.QueryString["CustomerID"];
                if (!string.IsNullOrEmpty(customerId))
                {
                    // Müşteri bilgilerini doldur
                    LoadCustomerDetails(customerId);
                }
            }
        }
        private void LoadCustomerDetails(string customerId)
        {
            // Veritabanından veriyi çek
            using (SqlCommand command = new SqlCommand("SELECT FirstName, LastName, PhoneNumber, Age, Insurance, DriverLicenseClassType, Email FROM Customer WHERE CustomerId = @CustomerId", SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                command.Parameters.AddWithValue("@CustomerID", customerId);
                // Verileri okuyucu ile al
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) // Müşteri bilgilerini bulursa
                {
                    // TextBox'lara müşteri bilgilerini doldur
                    FirstNameTxt.Text = reader["FirstName"].ToString();
                    LastNameTxt.Text = reader["LastName"].ToString();
                    PhoneNumberTxt.Text = reader["PhoneNumber"].ToString();
                    EmailTxt.Text = reader["Email"].ToString();
                    AgeTxt.Text = reader["Age"].ToString();
                    InsuranceTxt.Text = reader["Insurance"].ToString();
                    DriverLicenseTxt.Text = reader["DriverLicenseClassType"].ToString();
                }
                else
                {
                    // Eğer müşteri bulunamazsa, gerekli işlemleri yapabilirsiniz
                    // Örneğin, bir hata mesajı göstermek
                    Response.Write("<script>alert('Customer not found');</script>");
                }

                // Okuyucuyu ve bağlantıyı kapat
                reader.Close();
            }

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Müşteri ID'sini al (QueryString'den veya başka bir şekilde saklanan değerden)
            string customerId = Request.QueryString["CustomerID"];

            if (!string.IsNullOrEmpty(customerId))
            {
                // Güncelleme sorgusu
                string query = @"UPDATE Customer
                         SET FirstName = @FirstName,
                             LastName = @LastName,
                             PhoneNumber = @PhoneNumber,
                             Email = @Email,
                             Age = @Age,
                             Insurance = @Insurance,
                             DriverLicenseClassType = @DriverLicenseClassType
                         WHERE CustomerId = @CustomerId";

                // Veritabanına bağlan ve sorguyu çalıştır
                using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
                {
                    SqlConnectionClass.CheckConnection();

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@FirstName", FirstNameTxt.Text);
                    command.Parameters.AddWithValue("@LastName", LastNameTxt.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumberTxt.Text);
                    command.Parameters.AddWithValue("@Email", EmailTxt.Text);
                    command.Parameters.AddWithValue("@Age", int.Parse(AgeTxt.Text)); // Yaşın bir tam sayı olduğundan emin olun
                    command.Parameters.AddWithValue("@Insurance", InsuranceTxt.Text);
                    command.Parameters.AddWithValue("@DriverLicenseClassType", DriverLicenseTxt.Text);
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    // Sorguyu çalıştır
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Güncelleme başarılıysa bir başarı mesajı gösterin
                        Response.Write("<script>alert('Customer updated successfully');</script>");
                    }
                    else
                    {
                        // Hiçbir kayıt etkilenmediyse, bir hata mesajı gösterin
                        Response.Write("<script>alert('Customer update failed');</script>");
                    }
                }
            }
            else
            {
                // Eğer müşteri ID bulunamazsa, bir hata mesajı gösterin
                Response.Write("<script>alert('Customer ID is missing');</script>");
            }
        }

    }
}