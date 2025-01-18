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
    public partial class CustomerLogInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CustomerLoginBtn_Click(object sender, EventArgs e)
        {
            // SQL Komutunu oluştur
            SqlCommand command = new SqlCommand(
                "Select CustomerID from Customer where Email = @Email and Password = @Password",
                SqlConnectionClass.connection
            );

            SqlConnectionClass.CheckConnection();

            // Parametreleri ekle
            command.Parameters.AddWithValue("@Email", email.Text);
            command.Parameters.AddWithValue("@Password", password.Text);

            // Veriyi okuyacak Reader nesnesi
            SqlDataReader dr = command.ExecuteReader();

            // Eğer giriş başarılıysa
            if (dr.Read())
            {
                // CustomerID'yi Session'da sakla
                Session["CustomerID"] = dr["CustomerID"].ToString();

                String CustomerID = dr["CustomerID"].ToString();

                // Başarı mesajı
                lblMessage.Text = "Giriş Başarılı!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Visible = true;

                // Sayfayı MainPage.aspx'e yönlendir
                Response.Redirect($"/Pages/CustomerPages/MainPage.aspx?CustomerID={CustomerID}");
            }
            else
            {
                // Giriş başarısız mesajı
                lblMessage.Text = "Giriş Başarısız. Lütfen bilgilerinizi kontrol edin!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }

            // Reader'ı ve bağlantıyı kapat
            dr.Close();
            SqlConnectionClass.connection.Close();
        }

    }
}