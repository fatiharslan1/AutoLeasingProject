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
    public partial class EmployeeAddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Branch bilgilerini doldur
                LoadBranchData();
            }
        }

        private void LoadBranchData()
        {
            // SQL sorgusu ile Branch tablosundan veri çek
            string query = "SELECT BranchID, Name FROM Branch";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                SqlDataReader reader = command.ExecuteReader();

                // DropDownList'e ilk 'Şube seçiniz' item'ını ekle
                BranchIDTxt.Items.Clear();
                BranchIDTxt.Items.Add(new ListItem("Şube seçiniz", "") { Selected = true });

                // Veritabanından gelen verileri DropDownList'e ekle
                while (reader.Read())
                {
                    string branchID = reader["BranchID"].ToString();
                    string branchName = reader["Name"].ToString();

                    // Branch'leri DropDownList'e ekle
                    BranchIDTxt.Items.Add(new ListItem(branchName, branchID));
                }

                reader.Close();
            }
        }

        protected void AddEmployeeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Employee (FirstName, LastName, PhoneNumber, Email, Salary, Position, Status, Password, BirthDate, BranchID) " +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Salary, @Position, @Status, @Password, @BirthDate, @BranchID)",
                    SqlConnectionClass.connection
                );

                SqlConnectionClass.CheckConnection();

                // Parametreler
                command.Parameters.AddWithValue("@FirstName", FirstNameTxt.Text);
                command.Parameters.AddWithValue("@LastName", LastNameTxt.Text);
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumberTxt.Text);
                command.Parameters.AddWithValue("@Email", EmailTxt.Text);
                command.Parameters.AddWithValue("@Salary", SalaryTxt.Text);
                command.Parameters.AddWithValue("@Position", PositionTxt.Text);
                command.Parameters.AddWithValue("@Status", StatusTxt.SelectedValue);
                command.Parameters.AddWithValue("@Password", PasswordTxt.Text);
                command.Parameters.AddWithValue("@BirthDate", AgeTxt.Text);
                command.Parameters.AddWithValue("@BranchID", BranchIDTxt.SelectedValue);

                // Komutu çalıştır
                command.ExecuteNonQuery();

                // Kayıt başarılı olduğunda ekrana alert mesajı yazdır
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Kayıt başarılı!');", true);
            }
            catch (Exception ex)
            {
                // Hata durumunda ekrana hata mesajı yazdır
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hata: " + ex.Message + "');", true);
            }
        }
    }
}