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
    public partial class EmployeeLogInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void EmployeeLoginBtn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Employee where Email = @Email  and Password = @Password", SqlConnectionClass.connection);

            SqlConnectionClass.CheckConnection();

            command.Parameters.AddWithValue("@Email", EmailTxt.Text);
            command.Parameters.AddWithValue("@Password", PasswordTxt.Text);

            SqlDataReader dr = command.ExecuteReader();
            // Eğer bir sonuç varsa giriş başarılı
            if (dr.Read())
            {
                // Giriş yapan kullanıcının ID'sini alın
                int EmployeeID = Convert.ToInt32(dr["EmployeeID"]);

                // ID'yi Session değişkenine kaydet
                Session["EmployeeID"] = EmployeeID;

                // AdminHomePage'e yönlendirin
                Response.Redirect($"/Pages/AdminPages/EmployeeHomePage.aspx?EmployeeID={EmployeeID}");
            }
            else
            {
                lblMessage.Text = "Giriş Başarısız. Lütfen bilgilerinizi kontrol edin!";
                lblMessage.ForeColor = System.Drawing.Color.Red; // Mesajı kırmızı renkte göster
                lblMessage.Visible = true;
            }

            // Veritabanı bağlantısını kapat
            dr.Close();
            SqlConnectionClass.connection.Close();


        }
    }
}