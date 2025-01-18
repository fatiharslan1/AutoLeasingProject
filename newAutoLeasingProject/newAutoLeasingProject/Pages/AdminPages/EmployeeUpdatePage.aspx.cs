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
    public partial class EmployeeUpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["EmployeeID"] != null)
                {
                    int employeeID = Convert.ToInt32(Request.QueryString["EmployeeID"]);
                    LoadEmployeeDetails(employeeID);
                }
                else
                {
                    Response.Write("Error: No Employee ID provided in the query string.");
                }

            }

        }
        private void LoadEmployeeDetails(int employeeID)
        {
            try
            {
                SqlConnectionClass.CheckConnection();

                // Veritabanından bilgileri çekme
                SqlCommand command = new SqlCommand("SELECT * FROM Employee WHERE EmployeeID = @EmployeeID", SqlConnectionClass.connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    // TextBox'lara değer atama
                    BranchIDTxt.Text = dr["BranchID"].ToString();
                    FirstNameTxt.Text = dr["FirstName"].ToString();
                    LastNameTxt.Text = dr["LastName"].ToString();
                    PhoneNumberTxt.Text = dr["PhoneNumber"].ToString();
                    EmailTxt.Text = dr["Email"].ToString();
                    SalaryTxt.Text = dr["Salary"].ToString();
                    PositionTxt.Text = dr["Position"].ToString();
                    StatusTxt.Text = dr["Status"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Car ID'sini al (QueryString'den veya başka bir şekilde saklanan değerden)
            string EmployeeID = Request.QueryString["EmployeeID"];

            if (!string.IsNullOrEmpty(EmployeeID))
            {
                // Güncelleme sorgusu
                string query = @"UPDATE Employee SET 
                                        BranchID = @BranchID,
                                        FirstName = @FirstName,
                                        LastName = @LastName,
                                        PhoneNumber = @PhoneNumber,
                                        Email = @Email,
                                        Salary = @Salary,
                                        Position = @Position,
                                        Status = @Status
                                     WHERE EmployeeID = @EmployeeID";

                // Veritabanına bağlan ve sorguyu çalıştır
                using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
                {
                    SqlConnectionClass.CheckConnection();

                    // Parametreleri tanımla
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    command.Parameters.AddWithValue("@BranchID", BranchIDTxt.Text);
                    command.Parameters.AddWithValue("@FirstName", FirstNameTxt.Text);
                    command.Parameters.AddWithValue("@LastName", LastNameTxt.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumberTxt.Text);
                    command.Parameters.AddWithValue("@Email", EmailTxt.Text);
                    command.Parameters.AddWithValue("@Salary", SalaryTxt.Text);
                    command.Parameters.AddWithValue("@Position", PositionTxt.Text);
                    command.Parameters.AddWithValue("@Status", StatusTxt.Text);

                    // Sorguyu çalıştır
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Güncelleme başarılıysa bir başarı mesajı gösterin
                        Response.Write("<script>alert('Çalışan başarı ile güncellendi');</script>");
                    }
                    else
                    {
                        // Hiçbir kayıt etkilenmediyse, bir hata mesajı gösterin
                        Response.Write("<script>alert('Çalışan güncellenemedi');</script>");
                    }
                }
            }
            else
            {
                // Eğer müşteri ID bulunamazsa, bir hata mesajı gösterin
                Response.Write("<script>alert('Çalışan ID si eksik');</script>");
            }
        }

    }
}