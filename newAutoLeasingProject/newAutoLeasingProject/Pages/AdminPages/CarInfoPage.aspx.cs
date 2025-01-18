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
    public partial class CarInfoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarData();
                BindBrands();
                BindTransmission();
                BindYear();
                BindInsurance();
                BindCarType();
                BindBranch();
                BindFuelType();
                BindInSituation();

                // Model dropdown'ını boşalt
                ModelDropdown.Items.Clear();
                ModelDropdown.Items.Insert(0, new ListItem("Any", "")); // "Any" seçeneğini ekle
            }

        }
        private void BindCarData()
        {
            // Veritabanından veriyi çek
            using (SqlCommand command = new SqlCommand("SELECT Car.CarID, Car.Brand, Car.Model, Car.Year, " +
        "CASE WHEN Car.Transmission = 1 THEN 'Otomatik' ELSE 'Manuel' END AS Transmission, " +
        "Car.LicensePlate, Car.Insurance, Car.VINNumber, Car.TypeName, Car.InSituation, Branch.Name AS BranchName " +
        "FROM Car INNER JOIN Branch ON Car.BranchID = Branch.BranchID",
    SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Veriyi Repeater'a bağla
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();


                }
            }
        }



        private void BindInsurance()
        {
            string query = "SELECT DISTINCT Insurance FROM Car";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                SqlDataReader reader = command.ExecuteReader();

                // Dropdown'u temizle ve tekrarları engellemek için HashSet kullan
                InsuranceDropDown.Items.Clear();
                HashSet<string> addedItems = new HashSet<string>();

                while (reader.Read())
                {
                    // Veritabanındaki Insurance sütunundaki değeri oku
                    string InsuranceValue = reader["Insurance"].ToString();

                    // Değerin metin karşılığını belirle
                    string text = InsuranceValue == "True" ? "Var" : "Yok";

                    // Eğer bu değer daha önce eklenmediyse dropdown'a ekle
                    if (!addedItems.Contains(InsuranceValue))
                    {
                        InsuranceDropDown.Items.Add(new ListItem(text, InsuranceValue));
                        addedItems.Add(InsuranceValue);
                    }
                }

                reader.Close();
            }

            // "Any" seçeneğini manuel olarak en üst sıraya ekle
            InsuranceDropDown.Items.Insert(0, new ListItem("Any", ""));
        }



        private void BindInSituation()
        {
            // InSituation sütunundaki benzersiz değerleri almak için sorgu
            string query = "SELECT DISTINCT InSituation FROM Car";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                // Bağlantıyı kontrol et ve aç
                SqlConnectionClass.CheckConnection();

                // Veri okuyucu oluştur
                SqlDataReader reader = command.ExecuteReader();

                // DropDownList için veri kaynağını temizle
                InSituationDropDown.Items.Clear();

                // "Any" seçeneğini manuel olarak ekle
                InSituationDropDown.Items.Insert(0, new ListItem("Herhangi Biri", ""));

                while (reader.Read())
                {
                    // InSituation değerini string olarak al
                    string InSituationValue = reader["InSituation"].ToString();

                    // Değere göre kullanıcıya gösterilecek metni belirle
                    string text;
                    switch (InSituationValue)
                    {
                        case "Servis":
                            text = "Serviste";
                            break;
                        case "Müsait":
                            text = "Kullanıma Uygun";
                            break;
                        case "Kirada":
                            text = "Kirada";
                            break;
                        default:
                            text = "Bilinmiyor";
                            break;
                    }

                    // DropDownList'e yeni bir ListItem ekle
                    InSituationDropDown.Items.Add(new ListItem(text, InSituationValue));
                }

                // Veri okuyucuyu kapat
                reader.Close();
            }
        }

        private void BindCarType()
        {
            // Var tablosundan benzersiz TypeName değerlerini alacak sorgu
            string query = "SELECT DISTINCT TypeName FROM Car";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                // Bağlantıyı kontrol et ve aç
                SqlConnectionClass.CheckConnection();

                // Veri okuyucu oluştur
                SqlDataReader reader = command.ExecuteReader();

                // Dropdown için veri kaynağını temizle
                TypeNameDropDown.Items.Clear();

                while (reader.Read())
                {
                    // TypeName değerini string olarak al ve dropdown listesine ekle
                    string typeName = reader["TypeName"].ToString();
                    TypeNameDropDown.Items.Add(new ListItem(typeName, typeName));
                }

                // Veri okuyucuyu kapat
                reader.Close();
            }

            // "Any" seçeneğini manuel olarak ekle
            TypeNameDropDown.Items.Insert(0, new ListItem("Any", ""));
        }


        private void BindBranch()
        {
            // SQL sorgusu ile Branch tablosundan veri çek
            string query = "SELECT BranchID, Name FROM Branch";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                SqlDataReader reader = command.ExecuteReader();

                // DropDownList'e ilk 'Şube seçiniz' item'ını ekle
                BranchNameDropDown.Items.Clear();

                // Veritabanından gelen verileri DropDownList'e ekle
                while (reader.Read())
                {
                    string branchID = reader["BranchID"].ToString();
                    string branchName = reader["Name"].ToString();

                    // Branch'leri DropDownList'e ekle
                    BranchNameDropDown.Items.Add(new ListItem(branchName, branchID));
                }

                reader.Close();
            }
            // "Any" seçeneğini manuel olarak ekle
            BranchNameDropDown.Items.Insert(0, new ListItem("Any", ""));
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



        private void BindYear()
        {
            // Car tablosundan benzersiz yıl değerlerini alacak sorgu
            string query = "SELECT DISTINCT Year FROM Car";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                // Bağlantıyı kontrol et ve aç
                SqlConnectionClass.CheckConnection();

                // Veri okuyucu oluştur
                SqlDataReader reader = command.ExecuteReader();

                // Dropdown için veri kaynağını temizle
                YearDropDown.Items.Clear();

                while (reader.Read())
                {
                    // Year değerini dropdown listesine ekle
                    YearDropDown.Items.Add(new ListItem(reader["Year"].ToString(), reader["Year"].ToString()));
                }

                // Veri okuyucuyu kapat
                reader.Close();
            }

            // "Any" seçeneğini manuel olarak ekle
            YearDropDown.Items.Insert(0, new ListItem("Any", ""));
        }

        private void BindBrands()
        {
            // SQL sorgusu
            string query = "SELECT DISTINCT Brand FROM Car";

            // Veritabanı bağlantısı
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
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
        protected void BrandDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBrand = BrandDropdown.SelectedValue;

            if (!string.IsNullOrEmpty(selectedBrand))
            {
                BindModels(selectedBrand);
            }
            else
            {
                // Brand seçilmemişse, Model dropdown'ını boşalt
                ModelDropdown.Items.Clear();
            }
        }

        private void BindModels(string brand)
        {
            // SQL sorgusu, markaya bağlı modelleri çekmek için
            string query = "SELECT DISTINCT Model FROM Car WHERE Brand = @Brand";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@Brand", brand);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ModelDropdown.Items.Clear(); // Önceki model seçeneklerini temizle

                    // Model dropdown'ını doldur
                    while (reader.Read())
                    {
                        ModelDropdown.Items.Add(new ListItem(reader["Model"].ToString()));
                    }
                }
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
                    string text = transmissionValue == "True" ? "Otomatik" : "Manuel";

                    // DropDownList'e yeni bir ListItem ekle
                    TransmissionDropdown.Items.Add(new ListItem(text, transmissionValue));
                }

                reader.Close();
            }

            // "Any" seçeneğini manuel olarak ekle
            TransmissionDropdown.Items.Insert(0, new ListItem("Any", ""));
        }
        protected void FilterBtn_Click(object sender, EventArgs e)
        {


            // Filtreleri oku
            string selectedYear = YearDropDown.SelectedValue;
            string selectedBrand = BrandDropdown.SelectedValue;
            string selectedTransmission = TransmissionDropdown.SelectedValue;
            string selectedInsurance = InsuranceDropDown.SelectedValue;
            string selectedInSituation = InSituationDropDown.SelectedValue;
            string selectedTypeName = TypeNameDropDown.SelectedValue;
            string selectedBranch = BranchNameDropDown.SelectedValue;
            string selectedModel = ModelDropdown.SelectedValue; // Model filtresi



            // SQL sorgusunu dinamik olarak oluştur
            string query = "SELECT Car.CarID, Car.Brand, Car.Model, Car.Year, " +
                "CASE WHEN Car.Transmission = 1 THEN 'Otomatik' ELSE 'Manuel' END AS Transmission, " +
                "Car.LicensePlate, Car.Insurance, Car.VINNumber, Car.TypeName, Car.InSituation,  Branch.Name AS BranchName " +
                "FROM Car INNER JOIN Branch ON Car.BranchID = Branch.BranchID WHERE 1=1";

            // Filtreye göre sorguya şart ekle
            if (!string.IsNullOrEmpty(selectedYear))
                query += " AND Car.Year = @Year";
            if (!string.IsNullOrEmpty(selectedBrand))
                query += " AND Car.Brand = @Brand";
            if (!string.IsNullOrEmpty(selectedTransmission))
                query += " AND Car.Transmission = @Transmission";
            if (!string.IsNullOrEmpty(selectedInsurance))
                query += " AND Car.Insurance = @Insurance";
            if (!string.IsNullOrEmpty(selectedTypeName))
                query += " AND Car.TypeName = @TypeName";
            if (!string.IsNullOrEmpty(selectedBranch))
                query += " AND Car.BranchID = @BranchID";
            if (!string.IsNullOrEmpty(selectedInSituation))
                query += " AND Car.InSituation = @InSituation";
            if (!string.IsNullOrEmpty(selectedModel)) // Model filtresi
                query += " AND Car.Model = @Model"; // Model filtresi

            // Veriyi çek
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                // Parametreleri ekle
                if (!string.IsNullOrEmpty(selectedYear))
                    command.Parameters.AddWithValue("@Year", selectedYear);
                if (!string.IsNullOrEmpty(selectedBrand))
                    command.Parameters.AddWithValue("@Brand", selectedBrand);
                if (!string.IsNullOrEmpty(selectedTransmission))
                    command.Parameters.AddWithValue("@Transmission", selectedTransmission);
                if (!string.IsNullOrEmpty(selectedInsurance))
                    command.Parameters.AddWithValue("@Insurance", selectedInsurance);
                if (!string.IsNullOrEmpty(selectedTypeName))
                    command.Parameters.AddWithValue("@TypeName", selectedTypeName);
                if (!string.IsNullOrEmpty(selectedBranch))
                    command.Parameters.AddWithValue("@BranchID", selectedBranch);
                if (!string.IsNullOrEmpty(selectedInSituation))
                    command.Parameters.AddWithValue("@InSituation", selectedInSituation);
                if (!string.IsNullOrEmpty(selectedModel)) // Model filtresi parametre
                    command.Parameters.AddWithValue("@Model", selectedModel);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Filtrelenmiş veriyi Repeater'a bağla
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                }
            }
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            // Tüm dropdown'ları sıfırla
            YearDropDown.SelectedIndex = 0;
            BrandDropdown.SelectedIndex = 0;
            TransmissionDropdown.SelectedIndex = 0;
            InsuranceDropDown.SelectedIndex = 0;
            TypeNameDropDown.SelectedIndex = 0;
            BranchNameDropDown.SelectedIndex = 0;
            InSituationDropDown.SelectedIndex = 0;

            // Model dropdown'ını sıfırla
            ModelDropdown.Items.Clear();
            ModelDropdown.Items.Insert(0, new ListItem("Any", "")); // Varsayılan seçenek ekle

            // Tüm veriyi tekrar yükle
            BindCarData();
        }




        protected void CarAddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/Pages/AdminPages/CarAddPage.aspx");
        }

        protected void InfoButton_Click(object sender, EventArgs e) 
        {
            // Tıklanan butonun CommandArgument'ından müşteri ID'sini al
            string CarID = ((Button)sender).CommandArgument;

            // Müşteri bilgileri sayfasına yönlendirme
            Response.Redirect($"/Pages/AdminPages/CarUpdatePage.aspx?CarID={CarID}");
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            // Tıklanan düğmeyi belirleyin
            Button deleteButton = (Button)sender;

            // CommandArgument üzerinden CustomerID değerini alın
            string CarID = deleteButton.CommandArgument;

            try
            {
                // Bağlantıyı kontrol edin ve açın
                SqlConnectionClass.CheckConnection();

                // SQL komutunu oluşturun
                SqlCommand command = new SqlCommand("DELETE FROM Car WHERE CarID = @CarID", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@CarID", CarID);

                // Sorguyu çalıştırın
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Başarı mesajını göster
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Araba başarıyla silindi.');", true);
                }
                else
                {
                    // Eğer kayıt bulunamazsa
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Araba bulunamadı.');", true);
                }
            }
            catch (Exception ex)
            {
                // Hataları yakalayın ve gösterin
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Hata: {ex.Message}');", true);
            }
            finally
            {
                // Bağlantıyı kapatın
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }

            // Sayfayı yenileyerek güncel tabloyu göster
            Response.Redirect(Request.RawUrl);
        }

    }

}