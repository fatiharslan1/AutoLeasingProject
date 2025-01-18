using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class CarUpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Query string'den müşteri ID'sini al
                string CarID = Request.QueryString["CarID"];
                if (!string.IsNullOrEmpty(CarID))
                {
                    // Müşteri bilgilerini doldur
                    LoadCarDetails(CarID);
                }
            }
        }
        private void LoadCarDetails(string CarID)
        {
            // Veritabanından veriyi çek
            using (SqlCommand command = new SqlCommand("SELECT Brand, Model,  Year, VINNumber, LicensePlate, Insurance, InSituation, BranchID, TypeName, CarImage, Transmission, FuelType , CarKM FROM Car WHERE CarID = @CarID", SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                command.Parameters.AddWithValue("@CarID", CarID);
                // Verileri okuyucu ile al
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) // Araç bilgilerini bulursa
                {
                    // TextBox'lara müşteri bilgilerini doldur
                    BrandTxt.Text = reader["Brand"].ToString();
                    ModelTxt.Text = reader["Model"].ToString();
                    Year.Text = reader["Year"].ToString();
                    VINNumberTxt.Text = reader["VINNumber"].ToString();
                    LicensePlateTxt.Text = reader["LicensePlate"].ToString();
                    InsuranceTxt.Text = reader["Insurance"].ToString();
                    InSituationDropdown.SelectedValue = reader["InSituation"].ToString();
                    BranchNameTxt.Text = reader["BranchID"].ToString();
                    TypeNameTxt.Text = reader["TypeName"].ToString();
                    CarImageTxt.Text = reader["CarImage"].ToString();
                    TransmissionTxt.Text = reader["Transmission"].ToString();
                    FuelTypeTxt.Text = reader["FuelType"].ToString();
                    CarKMTxt.Text = reader["CarKM"].ToString();
                }
                else
                {
                    // Eğer müşteri bulunamazsa, gerekli işlemleri yapabilirsiniz
                    // Örneğin, bir hata mesajı göstermek
                    Response.Write("<script>alert('Car not found');</script>");
                }

                // Okuyucuyu ve bağlantıyı kapat
                reader.Close();
            }

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Car ID'sini al (QueryString'den veya başka bir şekilde saklanan değerden)
            string CarID = Request.QueryString["CarID"];

            if (!string.IsNullOrEmpty(CarID))
            {
                // Güncelleme sorgusu
                string query = @"UPDATE Car 
            SET Brand = @Brand, 
            Model = @Model, 
            Year = @Year, 
            VINNumber = @VINNumber, 
            LicensePlate = @LicensePlate, 
            Insurance = @Insurance, 
            InSituation = @InSituation, 
            BranchID = @BranchID, 
            TypeName = @TypeName, 
            CarImage = @CarImage, 
            Transmission = @Transmission, 
            FuelType = @FuelType, 
            CarKM = @CarKM 
            WHERE CarID = @CarID";

            // Veritabanına bağlan ve sorguyu çalıştır
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                // Parametrelerin değerlerini ekle
                command.Parameters.AddWithValue("@Brand", BrandTxt.Text);
                command.Parameters.AddWithValue("@Model", ModelTxt.Text);
                command.Parameters.AddWithValue("@Year", YearTxt.Text);
                command.Parameters.AddWithValue("@VINNumber", VINNumberTxt.Text);
                command.Parameters.AddWithValue("@LicensePlate", LicensePlateTxt.Text);
                command.Parameters.AddWithValue("@Insurance", InsuranceTxt.Text);
                command.Parameters.AddWithValue("@InSituation", InSituationDropdown.SelectedValue);
                command.Parameters.AddWithValue("@BranchID", BranchNameTxt.Text);
                command.Parameters.AddWithValue("@TypeName", TypeNameTxt.Text);
                command.Parameters.AddWithValue("@CarImage", CarImageTxt.Text); // Eğer resim veri türü uygun ise
                command.Parameters.AddWithValue("@Transmission", TransmissionTxt.Text);
                command.Parameters.AddWithValue("@FuelType", FuelTypeTxt.Text);
                command.Parameters.AddWithValue("@CarKM", CarKMTxt.Text);
                command.Parameters.AddWithValue("@CarID", CarID); // @CarID parametresini ekleyin



                    // Sorguyu çalıştır
                    int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Güncelleme başarılıysa bir başarı mesajı gösterin
                    Response.Write("<script>alert('Araba başarı ile güncellendi');</script>");
                }
                else
                {
                    // Hiçbir kayıt etkilenmediyse, bir hata mesajı gösterin
                    Response.Write("<script>alert('Araba güncellenemedi');</script>");
                }
            }
        }
        else
         {
                // Eğer müşteri ID bulunamazsa, bir hata mesajı gösterin
              Response.Write("<script>alert('Araba ID si eksik');</script>");
          }
        }

    }
}