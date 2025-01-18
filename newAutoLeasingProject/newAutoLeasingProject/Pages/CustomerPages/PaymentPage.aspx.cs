using newAutoLeasingProject.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.CustomerPages
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string city = Session["City"].ToString();
            string carName = Session["CarName"].ToString();
            int rentalDays = Convert.ToInt32(Session["RentalDays"]);
            DateTime pickupDat = (DateTime)Session["PickupDate"];
            DateTime dropDate = (DateTime)Session["DropDate"];
            int BranchID = Convert.ToInt32(Session["BranchID"]);
            int CustomerID = Convert.ToInt32(Session["CustomerID"]);
            int carID = Convert.ToInt32(Session["CarID"]);



        }
        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/Pages/CustomerPages/RentalPage.aspx");

        }
        protected void PaymentBtn_Click(object sender, EventArgs e)
        {
            string city = Session["City"].ToString();
            string carName = Session["CarName"].ToString();
            int rentalDays = Convert.ToInt32(Session["RentalDays"]);
            DateTime pickupDate = (DateTime)Session["PickupDate"];
            DateTime dropDate = (DateTime)Session["DropDate"];
            int BranchID = Convert.ToInt32(Session["BranchID"]);
            int CustomerID = Convert.ToInt32(Session["CustomerID"]);
            int carID = Convert.ToInt32(Session["CarID"]);
            Decimal totalFee = Convert.ToDecimal(Session["DailyFee"]) * Convert.ToInt32(Session["RentalDays"]);
            



            // Kullanıcı sözleşmeyi kabul etti mi?
            if (!AgreementCheckBox.Checked)
            {
                lblAgreementError.Text = "Lütfen sözleşmeyi kabul ediniz.";
                lblAgreementError.Visible = true;
                return; // İşlemi durdur
            }

            // Sözleşme kabul edilmişse, ödeme işlemlerine devam et
            lblAgreementError.Visible = false;

            SqlCommand command = new SqlCommand("INSERT INTO  [Transaction] (PickupDateTime, DropDateTime, CustomerID, CarID, TotalFee, BranchID) " +
                "VALUES (@PickupDateTime, @DropDateTime, @CustomerID, @CarID, @TotalFee, @BranchID )",
                SqlConnectionClass.connection);


            command.Parameters.AddWithValue("@PickupDateTime", pickupDate);
            command.Parameters.AddWithValue("@DropDateTime", dropDate);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@CarID", carID);
            command.Parameters.AddWithValue("@TotalFee", totalFee);
            command.Parameters.AddWithValue("@BranchID", BranchID);

            
            SqlCommand command2 = new SqlCommand("INSERT INTO Budget (Date, DailyRevenue, BranchID) VALUES (@Date, @DailyRevenue, @BranchID)", SqlConnectionClass.connection);

            command2.Parameters.AddWithValue("@Date", pickupDate);
            command2.Parameters.AddWithValue("@DailyRevenue", totalFee);
            command2.Parameters.AddWithValue("@BranchID", BranchID);


            SqlCommand command3 = new SqlCommand("INSERT INTO Payment (CustomerID, CardUserName, CardNumber, ExpiryDate, CVV, BillingAddress) VALUES (@CustomerID, @CardUserName,@CardNumber , @ExpiryDate , @CVV , @BillingAddress )", SqlConnectionClass.connection);

            command3.Parameters.AddWithValue("@CustomerID", CustomerID);
            command3.Parameters.AddWithValue("@CardUserName", txtCardName.Text);
            command3.Parameters.AddWithValue("@CardNumber", txtCardNumber.Text);
            command3.Parameters.AddWithValue("@ExpiryDate", txtExpiryDate.Text);
            command3.Parameters.AddWithValue("@CVV", txtCVV.Text);
            command3.Parameters.AddWithValue("@BillingAddress", txtBillingAddress.Text);


            SqlCommand command4 = new SqlCommand("UPDATE Car  SET InSituation = 'Kirada'  WHERE CarID = @CarID", SqlConnectionClass.connection);

            command4.Parameters.AddWithValue("@CarID", carID);




            // Veritabanına ekle
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            command4.ExecuteNonQuery();

            // Başarı mesajı
            Response.Write("<script>alert('Ödeme işlemi başarı ile gerçekleşti.');</script>");

        }
    }
}