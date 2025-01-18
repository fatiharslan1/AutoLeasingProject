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
    public partial class BranchAddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddBranchBtn_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Branch (Name, City, Province, Country, StreetAddress, Phone) " +
                    "VALUES (@Name, @City, @Province, @Country, @StreetAddress, @Phone)",
                    SqlConnectionClass.connection
                );

                SqlConnectionClass.CheckConnection();

                // Parametreler
                command.Parameters.AddWithValue("@Name", BranchNameTxt.Text);
                command.Parameters.AddWithValue("@City", CityTxt.Text);
                command.Parameters.AddWithValue("@Province", ProvinceTxt.Text);
                command.Parameters.AddWithValue("@Country", CountryTxt.Text);
                command.Parameters.AddWithValue("@StreetAddress", StreetAddressTxt.Text);
                command.Parameters.AddWithValue("@Phone", PhoneTxt.Text);


                // Komutu çalıştır
                command.ExecuteNonQuery();

                // Kayıt başarılı olduğunda ekrana alert mesajı yazdır
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Kayıt başarılı!');", true);

                // TextBox'ları temizle
                BranchNameTxt.Text = string.Empty;
                CityTxt.Text = string.Empty;
                ProvinceTxt.Text = string.Empty;
                CountryTxt.Text = string.Empty;
                StreetAddressTxt.Text = string.Empty;
                PhoneTxt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                // Hata durumunda ekrana hata mesajı yazdır
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hata: " + ex.Message + "');", true);
            }
        }
    }
}