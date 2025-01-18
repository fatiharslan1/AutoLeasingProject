using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class DeliveryUpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string deliveryId = Request.QueryString["DeliveryID"];
                if (!string.IsNullOrEmpty(deliveryId))
                {
                    LoadDeliveryDetails(deliveryId);
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx");
                }
            }
        }

        private decimal delayFee = 0; // Global değişken

        private void LoadDeliveryDetails(string deliveryId)
        {
            string query = @"
        SELECT Delivery.DeliveryStatus, Delivery.DeliveryDate, Delivery.CarID, Car.TypeName, Delivery.BranchID
        FROM Delivery
        INNER JOIN Car ON Delivery.CarID = Car.CarID
        WHERE Delivery.DeliveryID = @DeliveryID";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@DeliveryID", deliveryId);
                SqlConnectionClass.CheckConnection();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Verileri doldur
                        deliveryID.Value = deliveryId;
                        string status = reader["DeliveryStatus"].ToString();
                        string carId = reader["CarID"].ToString();
                        string typeName = reader["TypeName"].ToString();
                        string branchId = reader["BranchID"].ToString();
                        DateTime deliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);

                        CarIDTextBox.Text = carId;
                        BranchIDTextBox.Text = branchId;
                        DeliveryIDTextBox.Text = deliveryId;

                        if (status == "Teslim Günü")
                        {
                            FeeTextBox.Text = "Ücret alınmadan teslim alabilirsiniz.";
                        }
                        else if (status == "Gecikmiş Teslim")
                        {
                            TimeSpan delay = DateTime.Now.Date - deliveryDate.Date;
                            int delayedDays = delay.Days;

                            decimal dailyFee = GetDailyFee(typeName);
                            delayFee = delayedDays * dailyFee * 2;

                            TextBox1.Text = delayFee.ToString();
                            FeeTextBox.Text = $"Gecikme Ücreti: {delayFee:C} ({delayedDays} gün gecikme)";
                        }
                    }
                    else
                    {
                        Response.Redirect("ErrorPage.aspx");
                    }
                }
            }
        }

        private decimal GetDailyFee(string typeName)
        {
            string query = "SELECT DailyFee FROM Type WHERE TypeName = @TypeName";
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@TypeName", typeName);
                SqlConnectionClass.CheckConnection();
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string deliveryId = deliveryID.Value;
                string kmUsed = KMTxt.Text.Trim();
                string employeeId = Session["EmployeeID"]?.ToString();

                string query = @"
                -- Delivery tablosunu güncelle
                UPDATE Delivery
                SET OdometerReading = @KM, DeliveryStatus = 'Teslim Edildi', EmployeeID = @EmployeeID
                WHERE DeliveryID = @DeliveryID;

                -- Car tablosunda CarKM'yi güncelle ve InSituation değerini güncelle
                UPDATE Car
                SET CarKM = CarKM + @KM, InSituation = 'Müsait'
                WHERE CarID = (SELECT CarID FROM Delivery WHERE DeliveryID = @DeliveryID);

                -- Transaction tablosunda LateFee'yi güncelle
                UPDATE [Transaction]
                SET LateFee = @LateFee
                WHERE TransactionID = (
                    SELECT TransactionID 
                    FROM Delivery 
                    WHERE DeliveryID = @DeliveryID
                ); -- Budget tablosuna yeni bir kayıt ekle
                   -- INSERT INTO Budget (Date, DailyRevenue, BranchID)
                   -- VALUES (@Date, @DailyRevenue, @BranchID);";

                using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
                {
                    command.Parameters.AddWithValue("@KM", kmUsed);
                    command.Parameters.AddWithValue("@DeliveryID", DeliveryIDTextBox.Text);
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    command.Parameters.AddWithValue("@Date", DateTime.Now.Date);

                    // Gecikme ücreti yoksa sıfır değerini ata
                    command.Parameters.AddWithValue("@LateFee", Convert.ToDecimal(TextBox1.Text.Trim()));
                    command.Parameters.AddWithValue("@DailyRevenue", Convert.ToDecimal(TextBox1.Text.Trim()));

                    command.Parameters.AddWithValue("@BranchID", BranchIDTextBox.Text);

                    SqlConnectionClass.CheckConnection();
                    command.ExecuteNonQuery();
                }

                Response.Redirect($"/Pages/AdminPages/DeliveryInfoPage.aspx?EmployeeID={employeeId}");
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