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
    public partial class CarReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChartData("InSituation", "BranchID");
            }
        }

        protected void btnFilterSituation_Click(object sender, EventArgs e)
        {
            LoadChartData("InSituation", "BranchID");
        }


        protected void btnFilterType_Click(object sender, EventArgs e)
        {
            LoadChartData("TypeName", "BranchID");
        }

        protected void btnFilterFuel_Click(object sender, EventArgs e)
        {
            LoadChartData("FuelType", "BranchID");
        }

        protected void btnFilterYear_Click(object sender, EventArgs e)
        {
            LoadChartData("Year", "BranchID");
        }

        private int GetLoggedInEmployeeBranchID()
        {
            int employeeId = Convert.ToInt32(Request.QueryString["EmployeeID"]);
            int branchID = 0;

            string query = @"SELECT BranchID 
                         FROM Employee
                         WHERE EmployeeID = @EmployeeID";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                command.Parameters.AddWithValue("@EmployeeID", employeeId);

                branchID = Convert.ToInt32(command.ExecuteScalar()); // BranchID'yi alıyoruz
            }

            return branchID;
        }

        private void LoadChartData(string filterColumn, string groupColumn)
        {
            int branchID = GetLoggedInEmployeeBranchID(); // Çalışanın şubesi

            string query = $@"
        SELECT {filterColumn}, COUNT(*) AS Total
        FROM Car
        WHERE BranchID = @BranchID
        GROUP BY {filterColumn}
        ORDER BY {filterColumn}";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                command.Parameters.AddWithValue("@BranchID", branchID); // Şube filtrelemesi

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                string labels = string.Join(",", dt.AsEnumerable().Select(row => $"'{row[filterColumn]}'"));
                string data = string.Join(",", dt.AsEnumerable().Select(row => row["Total"].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "updateChart", $"updateChart([{labels}], [{data}]);", true);
            }
        }
    }
}
 