using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.CustomerPages
{
    public partial class CustomerSignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CustomerRegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL INSERT komutunu oluştur
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Customer (FirstName, LastName, PhoneNumber, Age, Insurance, DriverLicenseClassType, Email, Password) " +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Age, @Insurance, @DriverLicenseClassType, @Email, @Password)",
                    SqlConnectionClass.connection
                );

                // Bağlantıyı kontrol et
                SqlConnectionClass.CheckConnection();

                // Parametreleri ekle
                command.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                command.Parameters.AddWithValue("@LastName", TextBox2.Text);
                command.Parameters.AddWithValue("@PhoneNumber", TextBox3.Text);
                command.Parameters.AddWithValue("@Age", TextBox4.Text);
                command.Parameters.AddWithValue("@Insurance", Insurance.SelectedValue);
                command.Parameters.AddWithValue("@DriverLicenseClassType", DriverLicenseClassType.SelectedValue);
                command.Parameters.AddWithValue("@Email", TextBox5.Text);
                command.Parameters.AddWithValue("@Password", TextBox6.Text);

                // SQL komutunu çalıştır
                int result = command.ExecuteNonQuery();

                // Eğer etkilenen satır sayısı 1 ise işlem başarılıdır
                if (result > 0)
                {
                    lblMessage.Text = "Kayıt başarılı! Giriş sayfasına yönlendiriliyorsunuz...";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    // Giriş sayfasına yönlendirme
                    Response.Redirect($"/Pages/CustomerPages/CustomerLogInPage.aspx");
                }
                else
                {
                    lblMessage.Text = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                lblMessage.Text = "Hata: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
            
        }

    }
}