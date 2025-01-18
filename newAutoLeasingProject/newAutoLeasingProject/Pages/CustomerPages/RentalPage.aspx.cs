using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.CustomerPages
{
    public partial class RentalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string city = Session["City"].ToString();
                int rentalDays = Convert.ToInt32(Session["RentalDays"]);
                string pickupDate = Session["PickupDate"]?.ToString();
                string dropDate = Session["DropDate"]?.ToString();
                String CustomerID = Session["CustomerID"].ToString();


                LoadCarData();
                BindBrands();
                BindFuelType();
                BindLocation(city);
                BindTransmission();

                

                // Toplam fiyatı hesapla
                decimal totalPrice = rentalDays ;



                // Alınan City'yi bir kontrol ile sayfada göster
                lblCity.Text = "Seçilen Şehir: " + city;
                lblDays.Text = "Gün Sayısı: " + rentalDays;
                lblPickupDate.Text = " Alış tarihi " + pickupDate;
                lblDropDate.Text = "bırakma tarihi " + dropDate;

            }
        }
        private void BindFuelType()
        {
            // SQL sorgusu ile Branch tablosundan veri çek
            string query = "SELECT DISTINCT  FuelType FROM Car";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();


                // Veriyi oku
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Dropdown'u doldur
                    FuelTypeDropDown.DataSource = reader;
                    FuelTypeDropDown.DataTextField = "FuelType"; // Görünecek metin
                    FuelTypeDropDown.DataValueField = "FuelType"; // Değer
                    FuelTypeDropDown.DataBind();
                }

                // "Any" seçeneğini ekle
                FuelTypeDropDown.Items.Insert(0, new ListItem("Any", ""));
            }
        }

        private void BindLocation(string city)
        {
            // SQL sorgusu ile City'ye göre BranchName çek
            string query = "SELECT DISTINCT Name FROM Branch WHERE City = @City";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                // Şehir parametresini sorguya ekle
                command.Parameters.AddWithValue("@City", city);

                SqlConnectionClass.CheckConnection();

                // Veriyi oku
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Dropdown'u doldur
                    LocationDropDown.DataSource = reader;
                    LocationDropDown.DataTextField = "Name"; // Görünecek metin
                    LocationDropDown.DataValueField = "Name"; // Değer
                    LocationDropDown.DataBind();
                }

                // "Any" seçeneğini ekle
                LocationDropDown.Items.Insert(0, new ListItem("Any", ""));
            }
        }

        private void BindTransmission()
        {
            string query = "SELECT DISTINCT Transmission FROM Car";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Transmission sütunundaki değeri okuyup metne dönüştür
                    string transmissionValue = reader["Transmission"].ToString();
                    string text = transmissionValue == "True" ? "Automatic" : "Manual";

                    // DropDownList'e yeni bir ListItem ekle
                    TransmissionDropdown.Items.Add(new ListItem(text, transmissionValue));
                }

                reader.Close();
            }

            // "Any" seçeneğini manuel olarak ekle
            TransmissionDropdown.Items.Insert(0, new ListItem("Any", ""));
        }

        private void BindBrands()
        {
            // Session'dan City bilgisini al
            string city = Session["City"]?.ToString(); // Null kontrolü yap

            // Eğer city bilgisi boşsa hata kontrolü yap
            if (string.IsNullOrEmpty(city))
            {
                throw new Exception("City bilgisi bulunamadı. Lütfen Session['City'] değişkenini kontrol edin.");
            }

            // SQL sorgusu
            string query = @"
        SELECT DISTINCT c.Brand
        FROM Car c
        INNER JOIN Branch b ON c.BranchID = b.BranchID
        WHERE b.City = @City";

            // Veritabanı bağlantısı
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                // City parametresini ekle
                command.Parameters.AddWithValue("@City", city);

                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // Veriyi oku
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Dropdown'u doldur
                    BrandDropdown.DataSource = reader;
                    BrandDropdown.DataTextField = "Brand"; // Görünecek metin
                    BrandDropdown.DataValueField = "Brand"; // Değer
                    BrandDropdown.DataBind();
                }

                // "Any" seçeneğini ekle
                BrandDropdown.Items.Insert(0, new ListItem("Any", ""));
            }
        }


        protected void FilterBtn_Click(object sender, EventArgs e)
        {
            // Bir önceki sayfadan gelen şehir bilgisi
            string city = Session["City"]?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(city))
            {
                throw new Exception("Session['City'] değeri boş. Lütfen geçerli bir şehir seçildiğinden emin olun.");
            }

            // Kullanıcının filtre seçeneklerini al
            string transmission = TransmissionDropdown.SelectedValue; // "True", "False" veya boş
            string brand = BrandDropdown.SelectedValue; // Seçilen marka
            string fueltype = FuelTypeDropDown.SelectedValue; // Seçilen yakıt türü
            string location = LocationDropDown.SelectedValue; // Seçilen şehir


            // SQL sorgusunu oluştur
            string query = @"
        SELECT c.CarID, c.Brand, c.Model, c.Year, c.TypeName, t.DailyFee, b.City, c.CarImage, c.Transmission, c.FuelType, c.BranchID, c.InSituation 
FROM Car c
INNER JOIN Branch b ON c.BranchID = b.BranchID
INNER JOIN Type t ON c.TypeName = t.TypeName
WHERE     c.InSituation = 'Müsait' AND
    b.City = @City AND
    (@Transmission IS NULL OR c.Transmission = @Transmission) AND
    (@FuelType IS NULL OR c.FuelType = @FuelType) AND
    (@Location IS NULL OR b.Name = @Location) AND
    (@Brand IS NULL OR c.Brand = @Brand);"; 

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                // Şehir parametresini sorguya ekle
                command.Parameters.AddWithValue("@City", city);

                // Parametreleri ekle
                // Transmission parametresi
                if (string.IsNullOrEmpty(transmission))
                    command.Parameters.AddWithValue("@Transmission", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Transmission", transmission);

                //fuelType
                if (string.IsNullOrEmpty(fueltype))
                    command.Parameters.AddWithValue("@FuelType", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@FuelType", fueltype);

                // Location parametresi
                if (string.IsNullOrEmpty(location))
                    command.Parameters.AddWithValue("@Location", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Location", location);

                // Brand parametresi
                if (string.IsNullOrEmpty(brand))
                    command.Parameters.AddWithValue("@Brand", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Brand", brand);

               

                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // SQL sorgusunu çalıştır
                SqlDataReader reader = command.ExecuteReader();
                DataTable carTable = new DataTable();
                carTable.Load(reader);

                // Veriyi Repeater'a bağla
                carRepeater.DataSource = carTable;
                carRepeater.DataBind();

                reader.Close(); // Reader'ı kapat
            }
        }

        private void LoadCarData()
        {
            // Bir önceki sayfadan gelen şehir bilgisi
            string city = Session["City"]?.ToString(); // Seçilen şehir bilgisi

            // SQL sorgusunu oluştur
            string query = @"
    SELECT 
        c.CarID, 
        c.Brand, 
        c.Model, 
        c.Year, 
        c.TypeName, 
        t.DailyFee, 
        b.City, 
        c.CarImage, 
        c.Transmission, 
        c.FuelType,
        c.BranchID,
        c.InSituation 
    FROM 
        Car c
    INNER JOIN 
        Branch b ON c.BranchID = b.BranchID
    INNER JOIN 
        Type t ON c.TypeName = t.TypeName
    WHERE 
    c.InSituation = 'Müsait' AND
        b.City = @City;"; // Sadece city değişkenine göre filtrele

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                // Şehir parametresini sorguya ekle
                if (string.IsNullOrEmpty(city))
                {
                    throw new Exception("City değeri boş olamaz!"); // Şehir değeri zorunlu olduğu için hata fırlat
                }

                command.Parameters.AddWithValue("@City", city);

                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // SQL sorgusunu çalıştır
                SqlDataReader reader = command.ExecuteReader();
                DataTable carTable = new DataTable();
                carTable.Load(reader);

                // Veriyi Repeater'a bağla
                carRepeater.DataSource = carTable;
                carRepeater.DataBind();

                reader.Close(); // Reader'ı kapat
            }
        }



        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            // Tüm dropdown'ları sıfırla
            BrandDropdown.SelectedIndex = 0;
            TransmissionDropdown.SelectedIndex = 0;
            LocationDropDown.SelectedIndex = 0;
            FuelTypeDropDown.SelectedIndex = 0;
            

            // Tüm veriyi tekrar yükle
            LoadCarData();

        }

        protected void RentBtn_Click(object sender, EventArgs e)
        {
            string city = Session["City"].ToString();
            int rentalDays = Convert.ToInt32(Session["RentalDays"]);
            DateTime pickupDate = Convert.ToDateTime(Session["PickupDate"]);
            DateTime dropDate = Convert.ToDateTime(Session["DropDate"]);
            string customerID = Session["CustomerID"].ToString();

            // Button'ın CommandArgument özelliğini alıyoruz (CarID, BranchID, DailyFee, CarName)
            Button btn = (Button)sender;
            string[] commandArgs = btn.CommandArgument.Split(',');

            // CommandArgument değerlerini ayır ve değişkenlere ata
            string carID = commandArgs[0];
            string branchID = commandArgs[1];
            string dailyFee = commandArgs[2];
            string carName = commandArgs[3]; // Burada hata olmamalı

            // Bu verileri Session'a kaydediyoruz
            Session["CarID"] = carID;
            Session["BranchID"] = branchID;
            Session["DailyFee"] = dailyFee;
            Session["CarName"] = carName;

            // PaymentPage'e yönlendirme
            Response.Redirect($"/Pages/CustomerPages/PaymentPage.aspx?City={city}&RentalDays={rentalDays}&PickupDate={pickupDate}&DropDate={dropDate}&CarID={carID}&DailyFee={dailyFee}&CustomerID={customerID}&BranchID={branchID}&CarName={carName}");

        }
        }
}
