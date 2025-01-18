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
    public partial class TypeAddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddTypeBtn_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO Type (TypeName, DailyFee) VALUES (@TypeName, @DailyFee)";
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                // Parametreler
                command.Parameters.AddWithValue("@TypeName", TypeNameTxt.Text);
                command.Parameters.AddWithValue("@DailyFee", DailyFeeTxt.Text);

                // Komutu çalıştır
                command.ExecuteNonQuery();

                // Kayıt başarılı olduğunda ekrana alert mesajı yazdır
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Type Ekleme Başarılı!');", true);

                ClearTxt();

            }

         }

        private void ClearTxt()
        {
            // TextBox'ları temizle
            TypeNameTxt.Text = string.Empty;
            DailyFeeTxt.Text = string.Empty;
          

        }

    }
}