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
    public partial class TransactionInfoPage : System.Web.UI.Page
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

                BindTransactionData();
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

        private void BindTransactionData()
        {
            // BranchID'yi HiddenField'dan al
            int branchID = Convert.ToInt32(BranchIDHiddenField.Value);

            string query = @"
    SELECT 
    [Transaction].TransactionID, 
    [Transaction].PickupDateTime, 
    [Transaction].DropDateTime, 
    [Transaction].CustomerID, 
    [Transaction].CarID,  
    [Transaction].TotalFee,   
    [Transaction].BranchID,   
    [Transaction].LateFee, 
    CONCAT(Car.Brand, ' ', Car.Model) AS CarDetails, -- Marka ve model birleştirildi
    CONCAT(Customer.FirstName, ' ', Customer.LastName) AS FullName -- Ad ve soyad birleştirildi
FROM 
    [Transaction]
INNER JOIN 
    Branch ON [Transaction].BranchID = Branch.BranchID
INNER JOIN 
    Car ON [Transaction].CarID = Car.CarID
INNER JOIN 
    Customer ON [Transaction].CustomerID = Customer.CustomerID
WHERE 
    [Transaction].BranchID = @BranchID";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@BranchID", branchID); // Şubenin ID'si parametre olarak geçilecek

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
        protected void InfoButton_Click(object sender, EventArgs e)
        {
            // Tıklanan butonun CommandArgument'ından TransactionID'yi al
            Button clickedButton = (Button)sender;
            string transactionID = clickedButton.CommandArgument;

            // BranchID'yi HiddenField'dan al
            string branchID = BranchIDHiddenField.Value;

            // TransactionEditPage.aspx'e TransactionID ve BranchID bilgileriyle yönlendir
            Response.Redirect($"~/Pages/AdminPages/TransactionEditPage.aspx?TransactionID={transactionID}&BranchID={branchID}");
        }



    }
}