using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Helpers;
using System;
using System.Web.Security;

namespace SIICOP_V1._2
{
    public partial class Bienvenido_CEPREVIDE : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("CEPREVIDE"))
                {


                }
                else
                {
                    MembershipUser user = Membership.GetUser(false);
                    Membership.UpdateUser(user);
                    ctx.SaveChanges();
                    Session.Clear();
                    Session.Abandon();
                    FormsAuthentication.RedirectToLoginPage();
                    FormsAuthentication.SignOut();
                    RedirectHelper.Redirect(this.Response, "~/Inicio/Inicio.aspx");
                }
            }
        }
    }
}