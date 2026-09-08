using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Helpers;
using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Inicio
{
    public partial class Inicio : System.Web.UI.Page
    {
        string sUsuarioActual;
        SIICOPEntities ctx = new SIICOPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_LoggedIn(object sender, EventArgs e)
        {

        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                if (System.Web.Security.Membership.ValidateUser(Login.UserName, Login.Password))
                {
                    FormsAuthentication.SetAuthCookie(Login.UserName, true);
                    var a = ctx.Personales.Where(x => x.login == Login.UserName).FirstOrDefault();
                    var depen = a.Dependencia;

                    if (depen == "C4")
                    {
                        RedirectHelper.Redirect(this.Response, "~/Bienvenido_C4.aspx");
                    }
                    if (depen == "SSP DVI")
                    {
                        RedirectHelper.Redirect(this.Response, "~/TotalAccionesBeneficiados.aspx");
                    }
                    if (depen == "DGTSV")
                    {
                        RedirectHelper.Redirect(this.Response, "~/Bienvenido_DGTSV.aspx");
                    }

                    if (depen == "CEPREVIDE")
                    {
                        RedirectHelper.Redirect(this.Response, "~/Bienvenido_CEPREVIDE.aspx");
                    }

                    if (depen == "SESCESP")
                    {
                        RedirectHelper.Redirect(this.Response, "~/Bienvenido_CVcMyCPC.aspx");
                    }
                    if (depen == "DGRS")
                    {
                        RedirectHelper.Redirect(this.Response, "~/Bienvenido_DGRS.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "error()", true);

            }


        }
    }
}