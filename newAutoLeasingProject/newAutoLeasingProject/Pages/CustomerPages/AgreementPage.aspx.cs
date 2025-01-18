using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newAutoLeasingProject.Pages.CustomerPages
{
    public partial class AgreementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Eğer sayfa yenileniyorsa, hata mesajını gizle
            if (!IsPostBack)
            {
                ErrorLabel.Visible = false;
            }
        }

        protected void AcceptButton_Click(object sender, EventArgs e)
        {
            // Kullanıcı sözleşmeyi onayladı mı?
            if (!AgreementCheckBox.Checked)
            {
                ErrorLabel.Text = "Devam etmek için sözleşmeyi kabul etmelisiniz.";
                ErrorLabel.Visible = true;
                return;
            }

           

            // Sayfayı kapatmak için JavaScript kodunu çalıştır
            ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "window.close();", true);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Sayfayı kapatmak için JavaScript kodunu çalıştır
            ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "window.close();", true);

        }
    }
}
