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
    public partial class AddCarPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Session'dan EmployeeID al ve şube bilgilerini yükle
                if (Session["EmployeeID"] != null)
                {
                    int employeeID = Convert.ToInt32(Session["EmployeeID"]);
                    BranchIDHiddenField.Value = GetBranchIDByEmployee(employeeID).ToString();
                }
                else
                {
                    // Eğer Session yoksa yetki hatası veya giriş sayfasına yönlendirme
                    Response.Redirect("/Pages/AdminPages/EmployeeLoginPage.aspx");
                }

                LoadTypeData();
            }
        }

        // Çalışanın kayıtlı olduğu şube ID'sini al
        private int GetBranchIDByEmployee(int employeeID)
        {
            int branchID = -1;

            string query = "SELECT BranchID FROM Employee WHERE EmployeeID = @EmployeeID";
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                SqlConnectionClass.CheckConnection();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out branchID))
                {
                    return branchID;
                }
            }

            return branchID; // Şube ID bulunamazsa -1 döner
        }

        private void LoadTypeData()
        {
            string query = "SELECT TypeName FROM Type";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                SqlDataReader reader = command.ExecuteReader();

                TypeNameTxt.Items.Clear();
                TypeNameTxt.Items.Add(new ListItem("Araç tipi seçiniz", "") { Selected = true });

                while (reader.Read())
                {
                    string typeName = reader["TypeName"].ToString();
                    TypeNameTxt.Items.Add(new ListItem(typeName));
                }

                reader.Close();
            }
        }

        protected void AddCarBtn_Click(object sender, EventArgs e)
        {
            // BranchID'yi HiddenField'dan al
            int branchID = Convert.ToInt32(BranchIDHiddenField.Value);

            SqlCommand command = new SqlCommand("INSERT INTO Car (Brand, Model, Year, VINNumber, LicensePlate, Registration, Insurance, InSituation, BranchID, TypeName, CarImage, Transmission, FuelType, CarKM) " +
                "VALUES (@Brand, @Model, @Year, @VINNumber, @LicensePlate, @Registration, @Insurance, @InSituation, @BranchID, @TypeName, @CarImage, @Transmission, @FuelType , @CarKM)",
                SqlConnectionClass.connection);

            SqlConnectionClass.CheckConnection();

            command.Parameters.AddWithValue("@Brand", BrandTxt.Text);
            command.Parameters.AddWithValue("@Model", ModelTxt.Text);
            command.Parameters.AddWithValue("@Year", YearTxt.Text);
            command.Parameters.AddWithValue("@VINNumber", VINNumberTxt.Text);
            command.Parameters.AddWithValue("@LicensePlate", LicensePlateTxt.Text);
            command.Parameters.AddWithValue("@Registration", RegistrationTxt.Text);
            command.Parameters.AddWithValue("@Insurance", InsuranceDropdown.SelectedValue);
            command.Parameters.AddWithValue("@InSituation", InSituationDropdown.SelectedValue);
            command.Parameters.AddWithValue("@BranchID", branchID); // Şube ID'yi ekle
            command.Parameters.AddWithValue("@TypeName", TypeNameTxt.SelectedValue);
            command.Parameters.AddWithValue("@CarImage", CarImageTxt.Text);
            command.Parameters.AddWithValue("@Transmission", TransmissionDropDown.SelectedValue);
            command.Parameters.AddWithValue("@FuelType", FuelTypeDropDown.SelectedValue);
            command.Parameters.AddWithValue("@CarKM", CarKMTxt.Text);


            command.ExecuteNonQuery();

            // Başarı mesajı
            Response.Write("<script>alert('Araç başarıyla kaydedildi.');</script>");

            // Tüm alanları temizle
            ClearTxt();
        }

        private void ClearTxt()
        {
            // TextBox'ları temizle
            BrandTxt.Text = string.Empty;
            ModelTxt.Text = string.Empty;
            YearTxt.Text = string.Empty;
            VINNumberTxt.Text = string.Empty;
            LicensePlateTxt.Text = string.Empty;
            RegistrationTxt.Text = string.Empty;
            CarImageTxt.Text = string.Empty;
            CarKMTxt.Text = "0"; // Default değeri tekrar ayarla

            // DropDownList'leri temizle veya ilk değerine ayarla
            InsuranceDropdown.SelectedIndex = 0; // İlk eleman seçili
            InSituationDropdown.SelectedIndex = 0;
            TypeNameTxt.SelectedIndex = 0;
            TransmissionDropDown.SelectedIndex = 0;
            FuelTypeDropDown.SelectedIndex = 0;

        }

    }
}