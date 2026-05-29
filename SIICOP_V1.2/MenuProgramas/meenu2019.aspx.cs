using System;

namespace SIICOP_V1._2.MenuProgramas
{
    public partial class meenu2019 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (this.IsPostBack || this.User.IsInRole("SysAdmin") || (this.User.IsInRole("Administrador") || this.User.IsInRole("Foráneo")))
                {

                }
                else
                {
                    this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");

                }
            }
        }
    }
}