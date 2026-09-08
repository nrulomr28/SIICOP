using SIICOP_V1._2.Helpers;
using System;
using System.Web.Security;

namespace SIICOP_V1._2
{
    public partial class SiteV2Master
        : System.Web.UI.MasterPage
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {

        }

        protected void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            FormsAuthentication.SignOut();

            RedirectHelper.Redirect(this.Response, "~/Inicio/inicio_sesion.aspx");
        }
    }
}