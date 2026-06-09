using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Inicio
{
    public partial class inicio_sesion : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_LoggedIn(object sender, EventArgs e)
        {

        }
        protected void Login_Authenticate(
    object sender,
    AuthenticateEventArgs e)
        {
            try
            {
                if (!Membership.ValidateUser(
                        Login.UserName,
                        Login.Password))
                {
                    e.Authenticated = false;
                    return;
                }

                FormsAuthentication.SetAuthCookie(
                    Login.UserName,
                    true);

                //var usuario =
                //    ctx.Personales
                //       .FirstOrDefault(
                //            x => x.login == Login.UserName);

                //if (usuario == null)
                //{
                //    e.Authenticated = false;
                //    return;
                //}

                //var rutas =
                //    new Dictionary<string, string>
                //    {
                //{ "C4", "~/Bienvenido_C4.aspx" },
                //{ "SSP DVI", "~/TotalAccionesBeneficiados.aspx" },
                //{ "DGTSV", "~/Bienvenido_DGTSV.aspx" },
                //{ "CEPREVIDE", "~/Bienvenido_CEPREVIDE.aspx" },
                //{ "SESCESP", "~/Bienvenido_CVcMyCPC.aspx" },
                //{ "DGRS", "~/Bienvenido_DGRS.aspx" }
                //    };

                //if (rutas.TryGetValue(
                //        usuario.Dependencia,
                //        out string url))
                //{
                //    Response.Redirect(url);
                //}

                Response.Redirect(
                    "~/Inicio/Launcher.aspx");
            }
            catch (Exception ex)
            {
                // aquí podemos meter ErrorLogger después

                e.Authenticated = false;
            }
        }
    }
}