using newAutoLeasingProject.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class EmployeeHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        


        

        // Sayfa Yönlendirme Butonları
        protected void btnAddCarPage_Click(object sender, EventArgs e)
        {
            // Session'dan EmployeeID al ve ProfilePage'e yönlendir
            if (Session["EmployeeID"] != null)
            {
                int employeeID = Convert.ToInt32(Session["EmployeeID"]);              
                Response.Redirect($"/Pages/AdminPages/CarAddPage.aspx?EmployeeID={employeeID}");
            }
            else
            {
                Response.Write("Error: Employee ID not found in session.");
            }
            
        }

        protected void btnTransactionPage_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/Pages/AdminPages/TransactionInfoPage.aspx");
        }

        protected void btnCarTypePage_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/Pages/AdminPages/TypeAddPage.aspx");
        }

        protected void btnServisInfo_Click(object sender, EventArgs e)
        {
            // Session'dan EmployeeID al ve ProfilePage'e yönlendir
            if (Session["EmployeeID"] != null)
            {
                int employeeID = Convert.ToInt32(Session["EmployeeID"]);
                Response.Redirect($"/Pages/AdminPages/ServiceInfo.aspx?EmployeeID={employeeID}");
            }
            else
            {
                Response.Write("Error: Employee ID not found in session.");
            }
        }


        protected void btnBranchAddPage_Click(object sender, EventArgs e)
        {
            // Session'dan EmployeeID al ve pozisyonu kontrol et
            if (Session["EmployeeID"] != null)
            {
                int employeeID = Convert.ToInt32(Session["EmployeeID"]);
                string position = GetEmployeePosition(employeeID); // Pozisyon kontrolü

                if (position == "Müdür")
                {
                    // Eğer kullanıcı "Müdür" ise sayfaya yönlendir
                    Response.Redirect($"/Pages/AdminPages/BranchAddPage.aspx");
                }
                else
                {
                    // Eğer kullanıcı "Müdür" değilse yetkisiz erişim mesajı göster
                    Response.Write("<script>alert('Yetkiniz yok. Bu sayfaya yalnızca müdürler erişebilir.');</script>");
                }
            }
            else
            {
                // Eğer Session boşsa hata mesajı göster
                Response.Write("Error: Employee ID not found in session.");
            }
        }
        protected void btnBranchReportPage_Click(object sender, EventArgs e)
        {
            // Session'dan EmployeeID al ve pozisyonu kontrol et
            if (Session["EmployeeID"] != null)
            {
                int employeeID = Convert.ToInt32(Session["EmployeeID"]);
                string position = GetEmployeePosition(employeeID); // Pozisyon kontrolü

                if (position == "Müdür")
                {
                    // Eğer kullanıcı "Müdür" ise sayfaya yönlendir
                    Response.Redirect($"/Pages/AdminPages/BranchReportPage.aspx");
                }
                else
                {
                    // Eğer kullanıcı "Müdür" değilse yetkisiz erişim mesajı göster
                    Response.Write("<script>alert('Yetkiniz yok. Bu sayfaya yalnızca müdürler erişebilir.');</script>");
                }
            }
            else
            {
                // Eğer Session boşsa hata mesajı göster
                Response.Write("Error: Employee ID not found in session.");
            }
        }

        protected void btnEmployeePage_Click(object sender, EventArgs e)
        {
            // Session'dan EmployeeID al ve pozisyonu kontrol et
            if (Session["EmployeeID"] != null)
            {
                int employeeID = Convert.ToInt32(Session["EmployeeID"]);
                string position = GetEmployeePosition(employeeID); // Pozisyon kontrolü

                if (position == "Müdür")
                {
                    // Eğer kullanıcı "Müdür" ise sayfaya yönlendir
                    Response.Redirect($"/Pages/AdminPages/EmployeeInfoPage.aspx?EmployeeID={employeeID}");
                }
                else
                {
                    // Eğer kullanıcı "Müdür" değilse yetkisiz erişim mesajı göster
                    Response.Write("<script>alert('Yetkiniz yok. Bu sayfaya yalnızca müdürler erişebilir.');</script>");
                }
            }
            else
            {
                // Eğer Session boşsa hata mesajı göster
                Response.Write("Error: Employee ID not found in session.");
            }
        }

        protected void btnProfilePage_Click(object sender, EventArgs e)
        {
            // Session'dan EmployeeID al ve ProfilePage'e yönlendir
            if (Session["EmployeeID"] != null)
            {
                int employeeID = Convert.ToInt32(Session["EmployeeID"]);
                Response.Redirect($"/Pages/AdminPages/EmployeeProfilePage.aspx?EmployeeID={employeeID}");
            }
            else
            {
                Response.Write("Error: Employee ID not found in session.");
            }
        }

        protected void btnExitPage_Click(object sender, EventArgs e)
        {
            
                Response.Redirect($"/Pages/AdminPages/EmployeeLogInPage.aspx");
          
        }

        // Kullanıcının pozisyonunu kontrol eden bir metod
        private string GetEmployeePosition(int employeeID)
        {
            string position = string.Empty;
            string query = "SELECT Position FROM Employee WHERE EmployeeID = @EmployeeID";

            // Veritabanı bağlantısını başlat
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    position = result.ToString();
                }
            }

            return position;
        }
    }
}