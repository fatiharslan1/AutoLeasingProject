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
    public partial class DeliveryInfoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDeliveryStatus();
                BindDeliveryData();
            }
        }
        private void BindDeliveryStatus()
        {
            string query = "SELECT DISTINCT DeliveryStatus FROM Delivery";
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DeliveryStatusDropDown.DataSource = reader;
                    DeliveryStatusDropDown.DataTextField = "DeliveryStatus";
                    DeliveryStatusDropDown.DataValueField = "DeliveryStatus";
                    DeliveryStatusDropDown.DataBind();
                }
                DeliveryStatusDropDown.Items.Insert(0, new ListItem("Any", ""));
            }
        }
        protected string GetRowClass(string deliveryStatus)
        {
            switch (deliveryStatus)
            {
                case "Teslim Günü":
                    return "bg-yellow-200"; // Sarı arka plan
                case "Gecikmiş Teslim":
                    return "bg-red-200"; // Kırmızı arka plan
                default:
                    return ""; // Varsayılan arka plan (boş)
            }
        }
        private void BindDeliveryData()
        {
            // Session'dan EmployeeID alın
            string employeeID = Session["EmployeeID"]?.ToString();
            if (string.IsNullOrEmpty(employeeID))
            {
                // Eğer Session boşsa giriş sayfasına yönlendirin
                Response.Redirect($"/Pages/AdminPages/EmployeeLoginPage.aspx");
                return;
            }

            // EmployeeID üzerinden BranchID'yi alın
            string branchId = GetBranchIdByEmployeeId(employeeID);
            if (string.IsNullOrEmpty(branchId))
            {
                // Eğer BranchID alınamazsa, hata verin veya yönlendirin
                Response.Redirect("ErrorPage.aspx");
                return;
            }

            string query = @"SELECT Delivery.DeliveryID, Customer.FirstName, Customer.LastName,
                     Employee.FirstName as EmployeeFirstName, Employee.LastName as EmployeeLastName,
                     Car.Brand, Car.Model, Delivery.OdometerReading, Delivery.DeliveryStatus, 
                     Delivery.DeliveryDate, Delivery.TransactionID
                     FROM Delivery
                     INNER JOIN Customer ON Delivery.CustomerID = Customer.CustomerID
                     INNER JOIN Employee ON Delivery.EmployeeID = Employee.EmployeeID
                     INNER JOIN Car ON Delivery.CarID = Car.CarID
                     WHERE Delivery.BranchID = @BranchID AND Delivery.DeliveryStatus <> 'Teslim edildi'";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@BranchID", branchId);
                SqlConnectionClass.CheckConnection();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        protected void FilterBtn_Click(object sender, EventArgs e)
        {
            // Session'dan EmployeeID alın
            string employeeID = Session["EmployeeID"]?.ToString();
            if (string.IsNullOrEmpty(employeeID))
            {
                // Eğer Session boşsa giriş sayfasına yönlendirin
                Response.Redirect($"/Pages/AdminPages/EmployeeLoginPage.aspx");
                return;
            }

            // EmployeeID üzerinden BranchID'yi alın
            string branchId = GetBranchIdByEmployeeId(employeeID);
            if (string.IsNullOrEmpty(branchId))
            {
                // Eğer BranchID alınamazsa, hata verin veya yönlendirin
                Response.Redirect($"/Pages/AdminPages/EmployeeLoginPage.aspx");
                return;
            }

            string deliveryStatus = DeliveryStatusDropDown.SelectedValue;
            string customerName = "%" + CustomerNameTxt.Text.Trim() + "%";

            string query = @"SELECT Delivery.DeliveryID, Customer.FirstName, Customer.LastName,
                     Employee.FirstName as EmployeeFirstName, Employee.LastName as EmployeeLastName,
                     Car.Brand, Car.Model, Delivery.OdometerReading, Delivery.DeliveryStatus, 
                     Delivery.DeliveryDate, Delivery.TransactionID
                     FROM Delivery
                     INNER JOIN Customer ON Delivery.CustomerID = Customer.CustomerID
                     INNER JOIN Employee ON Delivery.EmployeeID = Employee.EmployeeID
                     INNER JOIN Car ON Delivery.CarID = Car.CarID
                     WHERE Delivery.BranchID = @BranchID AND Delivery.DeliveryStatus <> 'Teslim edildi'";

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                query += " AND (Customer.FirstName LIKE @CustomerName OR Customer.LastName LIKE @CustomerName)";
            }
            if (!string.IsNullOrWhiteSpace(deliveryStatus) && deliveryStatus != "Any")
            {
                query += " AND Delivery.DeliveryStatus = @DeliveryStatus";
            }

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@BranchID", branchId);

                if (!string.IsNullOrWhiteSpace(customerName))
                {
                    command.Parameters.AddWithValue("@CustomerName", customerName);
                }
                if (!string.IsNullOrWhiteSpace(deliveryStatus) && deliveryStatus != "Any")
                {
                    command.Parameters.AddWithValue("@DeliveryStatus", deliveryStatus);
                }

                SqlConnectionClass.CheckConnection();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        private string GetBranchIdByEmployeeId(string employeeId)
        {
            string query = "SELECT BranchID FROM Employee WHERE EmployeeID = @EmployeeID";
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                SqlConnectionClass.CheckConnection();
                object result = command.ExecuteScalar();
                return result?.ToString();
            }
        }


        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            DeliveryStatusDropDown.SelectedIndex = 0; // Dropdown'u sıfırla
            BindDeliveryData(); // Tüm veriyi tekrar yükle
        }
        //Teslim al

        protected void InfoButton_Click(object sender, EventArgs e)
        {

            // EmployeeID'yi oturumda saklayın
            Button InfoButton = (Button)sender;
            string deliveryID = InfoButton.CommandArgument;
            string employeeID = Session["EmployeeID"]?.ToString();
            string branchID = GetBranchIdByEmployeeId(employeeID);



            Response.Redirect($"/Pages/AdminPages/DeliveryUpdatePage.aspx?DeliveryID={deliveryID}&EmployeeID={employeeID}&BranchID={branchID}");
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Bugünün tarihini al
            DateTime today = DateTime.Now.Date;

            // SQL sorguları
            string updateDeliveryDayQuery = @"
        UPDATE Delivery
        SET DeliveryStatus = 'Teslim Günü'
        WHERE CAST(DeliveryDate AS DATE) = @Today 
          AND DeliveryStatus != 'Teslim Edildi'";

            string updateDelayedQuery = @"
        UPDATE Delivery
        SET DeliveryStatus = 'Gecikmiş Teslim'
        WHERE CAST(DeliveryDate AS DATE) < @Today 
          AND DeliveryStatus != 'Teslim Edildi'";

            string updateWaitDayQuery = @"
        UPDATE Delivery
        SET DeliveryStatus = 'Teslim Bekliyor'
        WHERE CAST(DeliveryDate AS DATE) > @Today 
          AND DeliveryStatus != 'Teslim Edildi'";

            try
            {
                // Veritabanı bağlantısını kontrol et
                SqlConnectionClass.CheckConnection();

                // Teslim günü olanları güncelle
                using (SqlCommand cmd = new SqlCommand(updateDeliveryDayQuery, SqlConnectionClass.connection))
                {
                    cmd.Parameters.AddWithValue("@Today", today);
                    cmd.ExecuteNonQuery();
                }

                // Gecikmiş teslim olanları güncelle
                using (SqlCommand cmd = new SqlCommand(updateDelayedQuery, SqlConnectionClass.connection))
                {
                    cmd.Parameters.AddWithValue("@Today", today);
                    cmd.ExecuteNonQuery();
                }

                // Teslim günü olanları güncelle
                using (SqlCommand cmd = new SqlCommand(updateWaitDayQuery, SqlConnectionClass.connection))
                {
                    cmd.Parameters.AddWithValue("@Today", today);
                    cmd.ExecuteNonQuery();
                }

                DeliveryStatusDropDown.SelectedIndex = 0; // Dropdown'u sıfırla
                BindDeliveryData();
                // Geri bildirim veya başarı mesajı
                // Örneğin:
                // lblStatus.Text = "Teslimat durumları güncellendi.";
            }
            catch (Exception ex)
            {
                // Hata işlemleri
                // Örneğin:
                // lblStatus.Text = "Hata: " + ex.Message;
                Console.WriteLine("Hata: " + ex.Message);
            }
        }



    }
}