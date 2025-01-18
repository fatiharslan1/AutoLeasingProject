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
    public partial class ServiceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmployeeID"] != null)
                {
                    int employeeID = Convert.ToInt32(Session["EmployeeID"]);
                    BranchIDHiddenField.Value = GetBranchIDByEmployee(employeeID).ToString();
                    BindServiceCars(); // Şubeye ait servis durumundaki araçları yükle
                }
                else
                {
                    Response.Redirect("/Pages/AdminPages/EmployeeLoginPage.aspx"); // Giriş sayfasına yönlendir
                }
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
        /// <summary>
        /// Serviste olan araçları Repeater'a bağlar.
        /// </summary>
        private void BindServiceCars()
        {
            try
            {
                // HiddenField'den BranchID'yi al
                int branchID = Convert.ToInt32(BranchIDHiddenField.Value);

                using (SqlCommand command = new SqlCommand(@"
            SELECT 
                CarID, 
                Brand, 
                Model, 
                Year, 
                LicensePlate, 
                TypeName, 
                InSituation, 
                BranchID 
            FROM Car 
            WHERE InSituation = 'Servis' AND BranchID = @BranchID",
                    SqlConnectionClass.connection))
                {
                    SqlConnectionClass.CheckConnection();

                    // BranchID parametresi ekleniyor
                    command.Parameters.AddWithValue("@BranchID", branchID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Repeater'a bağla
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sqlError", $"alert('SQL Hatası: {ex.Message}');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "generalError", $"alert('Genel Hata: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }


        /// <summary>
        /// Aracın durumunu 'Müsait' olarak günceller. Aracı Teslim Almaya yarar
        /// </summary>
        protected void InfoButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string carID = btn.CommandArgument;

            try
            {
                using (SqlCommand command = new SqlCommand(@"
    UPDATE Car 
    SET InSituation = 'Müsait', EndServiceTime = @EndServiceTime
    WHERE CarID = @CarID",
                    SqlConnectionClass.connection))
                {
                    SqlConnectionClass.CheckConnection();

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@CarID", carID);
                    command.Parameters.AddWithValue("@EndServiceTime", DateTime.Now.Date);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        BindServiceCars(); // Veriyi yeniden yükle
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Araç durumu Müsait olarak güncellendi ve EndServiceTime bugüne ayarlandı.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Araç durumu güncellenemedi.');", true);
                    }
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sqlError", $"alert('SQL Hatası: {ex.Message}');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "generalError", $"alert('Genel Hata: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == System.Data.ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }

        /// <summary>
        /// Tüm verileri yeniden yükler ve arayüzü günceller.
        /// </summary>
        protected void UpdateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // Delivery tablosunda güncelleme yaparak tetikleyiciyi çalıştır
                using (SqlCommand command = new SqlCommand(@"
            UPDATE Delivery
            SET OdometerReading = OdometerReading + 1 -- Mevcut kilometreyi tetiklemek için küçük bir artış
            WHERE CarID IN (SELECT CarID FROM Car WHERE InSituation != 'Servis')",
                    SqlConnectionClass.connection))
                {
                    SqlConnectionClass.CheckConnection();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        BindServiceCars(); // Verileri yeniden yükle
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Veriler başarıyla güncellendi ve tetikleyici çalıştırıldı.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Hiçbir kayıt güncellenmedi.');", true);
                    }
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sqlError", $"alert('SQL Hatası: {ex.Message}');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "generalError", $"alert('Genel Hata: {ex.Message}');", true);
            }
            finally
            {
                if (SqlConnectionClass.connection.State == ConnectionState.Open)
                {
                    SqlConnectionClass.connection.Close();
                }
            }
        }
    }
}