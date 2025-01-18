using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using newAutoLeasingProject.DataBase;
using System.Collections;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int branchID = GetLoggedInEmployeeBranchID();
                LoadDailyRevenue(branchID);
            }
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

        private void LoadDailyRevenue(int branchID)
        {
            string query = @"SELECT Date, SUM(DailyRevenue) AS TotalRevenue
                                 FROM Budget
                                 WHERE BranchID = @BranchID
                                 GROUP BY Date
                                 ORDER BY Date";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                command.Parameters.AddWithValue("@BranchID", branchID);

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                string labels = string.Join(",", dt.AsEnumerable().Select(row => $"'{Convert.ToDateTime(row["Date"]).ToString("yyyy-MM-dd")}'"));
                string data = string.Join(",", dt.AsEnumerable().Select(row => row["TotalRevenue"].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "updateChart", $"updateChart([{labels}], [{data}]);", true);
            }
        }
        protected void btnLoadDaily_Click(object sender, EventArgs e)
        {
            int branchID = GetLoggedInEmployeeBranchID();
            LoadDailyRevenue(branchID);

        }

        protected void btnLoadWeekly_Click(object sender, EventArgs e)
        {
            LoadRevenueByPeriod("WEEK", GetLoggedInEmployeeBranchID());
        }

        protected void btnLoadMonthly_Click(object sender, EventArgs e)
        {
            LoadRevenueByPeriod("MONTH", GetLoggedInEmployeeBranchID());
        }

        protected void btnLoadYearly_Click(object sender, EventArgs e)
        {
            LoadRevenueByPeriod("YEAR", GetLoggedInEmployeeBranchID());
        }

        private void LoadRevenueByPeriod(string period, int branchID)
        {
            string datePartFunction;

            // "period" değişkenine göre doğru SQL fonksiyonunu belirleyin
            switch (period.ToUpper())
            {
                case "WEEK":
                    datePartFunction = "DATEPART(WEEK, Date)";
                    break;
                case "MONTH":
                    datePartFunction = "DATEPART(MONTH, Date)";
                    break;
                case "YEAR":
                    datePartFunction = "DATEPART(YEAR, Date)";
                    break;
                default:
                    throw new ArgumentException("Invalid period specified.");
            }

            string query = $@"SELECT {datePartFunction} AS Period, SUM(DailyRevenue) AS TotalRevenue
                      FROM Budget
                      WHERE BranchID = @BranchID
                      GROUP BY {datePartFunction}
                      ORDER BY {datePartFunction}";

            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();

                command.Parameters.AddWithValue("@BranchID", branchID);

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                string labels = string.Join(",", dt.AsEnumerable().Select(row => $"'{row["Period"]}'"));
                string data = string.Join(",", dt.AsEnumerable().Select(row => row["TotalRevenue"].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "updateChart", $"updateChart([{labels}], [{data}]);", true);
            }
        }

    }
}