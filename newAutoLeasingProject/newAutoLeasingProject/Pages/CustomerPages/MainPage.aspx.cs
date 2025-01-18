using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using newAutoLeasingProject.DataBase;
using System.Runtime.ConstrainedExecution;

namespace newAutoLeasingProject.Pages.CustomerPages
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBranch();

            }
        }
        private void BindBranch()
        {
            // SQL sorgusu ile Branch tablosundan veri çek
            string query = "SELECT Distinct  City  FROM Branch";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                SqlDataReader reader = command.ExecuteReader();

                // DropDownList'e ilk 'Şube seçiniz' item'ını ekle
                CityDropDown.Items.Clear();

                // Veritabanından gelen verileri DropDownList'e ekle
                while (reader.Read())
                {
                    string branchName = reader["City"].ToString();

                    // Branch'leri DropDownList'e ekle
                    CityDropDown.Items.Add(new ListItem(branchName));
                }

                reader.Close();
            }
            // "Any" seçeneğini manuel olarak ekle
            CityDropDown.Items.Insert(0, new ListItem("Any", ""));
        }
        protected void SearchCarBtn_Click(object sender, EventArgs e)
        {
            // Seçilen şehir ve tarih bilgilerini al
            string city = CityDropDown.SelectedValue; // Seçilen şehir
            string dropOffDateString = TextBoxDropOffDate.Text; // Drop-off tarihi
            string pickupDateString = TextBoxPickupDate.Text; // Pickup tarihi

            // Tarihleri DateTime türüne dönüştürmeye çalışalım
            DateTime dropOffDate;
            DateTime pickupDate;

            bool isValidDropOff = DateTime.TryParse(dropOffDateString, out dropOffDate);
            bool isValidPickup = DateTime.TryParse(pickupDateString, out pickupDate);

            if (!isValidDropOff || !isValidPickup)
            {
                lblMessage.Text = "Lütfen geçerli tarihleri giriniz.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // Eğer pickup tarihi drop-off tarihinden önceyse hata mesajı göster
            if (dropOffDate < pickupDate )
            {
                lblMessage.Text = "Drop-off tarihi, Pickup tarihinden önce olamaz.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // Gün farkını hesapla
            int rentalDays = (dropOffDate - pickupDate).Days;

            // CustomerID'yi Session'dan al
            string customerID = Session["CustomerID"]?.ToString();

            // Eğer CustomerID boşsa, kullanıcıyı login sayfasına yönlendir
            if (string.IsNullOrEmpty(customerID))
            {
                Response.Redirect($"/Pages/CustomerPages/CustomerLoginPage.aspx");
                return; // Yönlendirme yapılınca kodun devamını çalıştırmamak için return kullanıyoruz
            }

            // Seçilen City bilgisini Session'a kaydet
            Session["City"] = city;
            Session["RentalDays"] = rentalDays;
            Session["PickupDate"] = pickupDate;
            Session["DropDate"] = dropOffDate;
            Session["CustomerID"] = customerID; // CustomerID'yi de Session'a kaydediyoruz

            // RentalPage'e yönlendirin
            Response.Redirect($"/Pages/CustomerPages/RentalPage.aspx?City={city}&RentalDays={rentalDays}&PickupDate={pickupDate}&DropDate={dropOffDate}&CustomerID={customerID}");
        }

    }
}