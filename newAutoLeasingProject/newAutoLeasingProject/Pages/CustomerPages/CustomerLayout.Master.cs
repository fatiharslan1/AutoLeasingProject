using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.CustomerPages
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected string CustomerID;

        protected void Page_Load(object sender, EventArgs e)
        {
            // URL'den CustomerID'yi alıyoruz
             CustomerID = Request.QueryString["CustomerID"];

            // Eğer CustomerID null veya boş ise login sayfasına yönlendirin
            if (string.IsNullOrEmpty(CustomerID))
            {
                Response.Redirect($"/Pages/CustomerPages/CustomerLoginPage.aspx");
                return;
            }

            // CustomerID'yi Session'a kaydetmek isterseniz:
            Session["CustomerID"] = CustomerID;
        }
    }
}