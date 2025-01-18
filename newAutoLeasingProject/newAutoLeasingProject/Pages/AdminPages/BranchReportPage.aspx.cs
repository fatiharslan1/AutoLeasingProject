using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using newAutoLeasingProject.DataBase;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class BranchReportPage : System.Web.UI.Page
    {
        public string BranchNames { get; private set; } // JavaScript'e gönderilecek şube isimleri
        public string BranchRevenues { get; private set; } // JavaScript'e gönderilecek gelirler

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBranchData();
            }
        }

        private void LoadBranchData()
        {
            string query = @"
                SELECT 
                    b.Name AS BranchName, 
                    SUM(bu.DailyRevenue) AS TotalRevenue
                FROM 
                    Branch b
                LEFT JOIN 
                    Budget bu ON b.BranchID = bu.BranchID
                GROUP BY 
                    b.Name";
            using (SqlCommand command = new SqlCommand(query, SqlConnectionClass.connection))
            {
                SqlConnectionClass.CheckConnection();
                SqlDataReader reader = command.ExecuteReader();
                var branchNames = new List<string>();
                var branchRevenues = new List<decimal>();

                while (reader.Read())
                {
                    // Şube adı null kontrolü
                    string branchName = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : "Unknown";

                    // Gelir null kontrolü
                    decimal totalRevenue = reader["TotalRevenue"] != DBNull.Value ? Convert.ToDecimal(reader["TotalRevenue"]) : 0;

                    branchNames.Add($"'{branchName}'");
                    branchRevenues.Add(totalRevenue);
                }

                // Verileri JavaScript'e uygun formatta hazırla
                BranchNames = string.Join(", ", branchNames);
                BranchRevenues = string.Join(", ", branchRevenues);
            }

        }
    }
}