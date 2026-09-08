using SIICOP_V1._2.Captura.DGTSV;
using SIICOP_V1._2.Helpers;
using SIICOP_V1._2.Sesion;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI;

namespace SIICOP_V1._2
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;


                try
                {
                    MembershipUser myObject = System.Web.Security.Membership.GetUser();
                    string UserID = myObject.ProviderUserKey.ToString();
                    
                }
                catch (Exception ex) { ex.GetBaseException(); }


            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

            var sesionesActivas = Application["SesionesActivas"] as Dictionary<string, string>;
            if (sesionesActivas != null && SesionUsuario.UsuarioLoggeado != null)
            {
                var usuario = SesionUsuario.UsuarioLoggeado;
                if (sesionesActivas.ContainsKey(usuario.usuario))
                {
                    sesionesActivas.Remove(usuario.usuario);
                    System.Diagnostics.Debug.WriteLine($"Sesión eliminada para usuario: {usuario.usuario}");
                }
            }

            FormsAuthentication.SignOut();

            SesionUsuario.CerrarSesion();

            Session.Clear();
            Session.Abandon();

            RedirectHelper.Redirect(this.Response, "~/Inicio/inicio_sesion.aspx");
        }

        protected void lnkbtnFormularioDGTV_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_idetificacion_diaria.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 21;
            this.Session["idReporte_Accion"] = 1;
            RedirectHelper.Redirect(this.Response, "~/Captura/DGTSV/Ficha_idetificacion_diaria.aspx");
        }
    }
}