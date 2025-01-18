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
    public partial class TransactionEditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // TransactionID parametresini al
                if (Request.QueryString["TransactionID"] != null)
                {
                    int transactionID;
                    if (int.TryParse(Request.QueryString["TransactionID"], out transactionID))
                    {
                        TransactionIDHiddenField.Value = transactionID.ToString();
                        LoadTransactionDetails(transactionID);
                    }
                    else
                    {
                        Response.Redirect("TransactionInfoPage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("TransactionInfoPage.aspx");
                }
            }
        }

        private void LoadTransactionDetails(int transactionID)
        {
            string query = @"
        SELECT 
            T.PickupDateTime, 
            T.DropDateTime, 
            T.CarID, 
            T.TotalFee, 
            C.TypeName, 
            Ty.DailyFee
        FROM 
            [Transaction] T
        INNER JOIN 
            Car C ON T.CarID = C.CarID
        INNER JOIN 
            Type Ty ON C.TypeName = Ty.TypeName
        WHERE 
            T.TransactionID = @TransactionID";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                command.Parameters.AddWithValue("@TransactionID", transactionID);
                SqlConnectionClass.CheckConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Pickup ve Drop tarihlerini doldur
                        PickupDateTimeHiddenField.Value = reader["PickupDateTime"].ToString();
                        DropDateTimeTextBox.Text = reader["DropDateTime"] != DBNull.Value
                            ? Convert.ToDateTime(reader["DropDateTime"]).ToString("yyyy-MM-ddTHH:mm")
                            : string.Empty;

                        // Gerekli bilgileri doldur
                        CarIDHiddenField.Value = reader["CarID"].ToString();
                        TotalFeeHiddenField.Value = reader["TotalFee"].ToString();
                        DailyFeeHiddenField.Value = reader["DailyFee"].ToString();
                    }
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                int transactionID = Convert.ToInt32(TransactionIDHiddenField.Value);
                DateTime newDropDateTime = Convert.ToDateTime(DropDateTimeTextBox.Text);
                DateTime pickupDateTime = Convert.ToDateTime(PickupDateTimeHiddenField.Value);
                decimal dailyFee = Convert.ToDecimal(DailyFeeHiddenField.Value);
                decimal oldTotalFee = Convert.ToDecimal(TotalFeeHiddenField.Value);
                int branchID = Convert.ToInt32(Request.QueryString["BranchID"]);

                // Yeni gün farkını hesapla
                int newDays = (newDropDateTime - pickupDateTime).Days;

                // Yeni ücret hesapla
                decimal newTotalFee = newDays * dailyFee;

                // Fiyat farkını ekle
                decimal updatedTotalFee = oldTotalFee + newTotalFee;

                // Transaction tablosunu güncelle
                string updateTransactionQuery = @"
            UPDATE [Transaction]
            SET 
                DropDateTime = @DropDateTime, 
                TotalFee = @TotalFee
            WHERE 
                TransactionID = @TransactionID";

                using (SqlCommand transactionCommand = new SqlCommand(updateTransactionQuery, SqlConnectionClass.connection))
                {
                    transactionCommand.Parameters.AddWithValue("@TransactionID", transactionID);
                    transactionCommand.Parameters.AddWithValue("@DropDateTime", newDropDateTime);
                    transactionCommand.Parameters.AddWithValue("@TotalFee", updatedTotalFee);

                    SqlConnectionClass.CheckConnection();
                    transactionCommand.ExecuteNonQuery();
                }

                // Budget tablosuna yeniTotalFee'yi ekle
                string insertBudgetQuery = @"
            INSERT INTO [Budget] (Date, DailyRevenue, BranchID)
            VALUES (@Date, @DailyRevenue, @BranchID)";

                using (SqlCommand budgetCommand = new SqlCommand(insertBudgetQuery, SqlConnectionClass.connection))
                {
                    budgetCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                    budgetCommand.Parameters.AddWithValue("@DailyRevenue", newTotalFee);
                    budgetCommand.Parameters.AddWithValue("@BranchID", branchID);

                    SqlConnectionClass.CheckConnection();
                    budgetCommand.ExecuteNonQuery();
                }

                // İşlem tamamlandıktan sonra yönlendirme
                Response.Redirect("TransactionInfoPage.aspx");
            }
            catch (Exception ex)
            {
                // Hata mesajı göster
                ErrorMessage.Text = "Güncelleme sırasında bir hata oluştu: " + ex.Message;
            }
        }

    }
}