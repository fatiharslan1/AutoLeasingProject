using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.AdminPages
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                string employeeId = Session["EmployeeID"].ToString();

                // Menü linklerini güncelle
                CarInfoPage.NavigateUrl = $"CarInfoPage.aspx?EmployeeID={employeeId}";
                CustomerInfoPage.NavigateUrl = $"CustomerInfoPage.aspx?EmployeeID={employeeId}";
                DeliveryInfoPage.NavigateUrl = $"DeliveryInfoPage.aspx?EmployeeID={employeeId}";
                BranchInfoPage.NavigateUrl = $"BranchInfoPage.aspx?EmployeeID={employeeId}";
                RevenueReportPage.NavigateUrl = $"RevenueReportPage.aspx?EmployeeID={employeeId}";
                CarReportPage.NavigateUrl = $"CarReportPage.aspx?EmployeeID={employeeId}";


            }
            else
            {
                // Eğer Session boşsa giriş sayfasına yönlendirin
                Response.Redirect($"/Pages/AdminPages/EmployeeLoginPage.aspx");
            }
        }


    }
}