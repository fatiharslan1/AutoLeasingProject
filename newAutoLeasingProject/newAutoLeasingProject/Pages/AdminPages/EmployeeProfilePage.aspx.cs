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
    public partial class EmployeeProfilePage : System.Web.UI.Page
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
                    BirthDateTxt.Text = Convert.ToDateTime(dr["BirthDate"]).ToString("yyyy-MM-dd");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}