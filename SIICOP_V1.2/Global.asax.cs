using SIICOP_V1._2.Clases.Helpers;
using SIICOP_V1._2.Helpers;
using SIICOP_V1._2.Sesion;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace SIICOP_V1._2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Application["SesionesActivas"] = new Dictionary<string, string>();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            ErrorLogger.Registrar(ex);

            Server.ClearError();

            if (ex is HttpException httpEx)
            {
                switch (httpEx.GetHttpCode())
                {
                    case 403:
                        RedirectHelper.Redirect(this.Response, "~/Error/ErrorAcceso.aspx");
                        return;

                    case 404:
                        RedirectHelper.Redirect(this.Response, "~/Error/Error404.aspx");
                        return;
                }
            }

            RedirectHelper.Redirect(this.Response, "~/Error/Error500.aspx");
        }

        //protected void Session_End(object sender, EventArgs e)
        //{
        //    // Limpiar la sesión activa cuando termina
        //    var sesionesActivas = Application["SesionesActivas"] as Dictionary<string, string>;
        //    if (sesionesActivas != null)
        //    {
        //        var usuario = SesionUsuario.UsuarioLoggeado;
        //        if (usuario != null && sesionesActivas.ContainsKey(usuario.usuario))
        //        {
        //            sesionesActivas.Remove(usuario.usuario);
        //        }
        //   }
        //}

        //protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.Session != null && SesionUsuario.EstaAutenticado)
        //    {
        //        var sesionesActivas = Application["SesionesActivas"] as Dictionary<string, string>;
        //        if (sesionesActivas != null)
        //        {
        //            var usuario = SesionUsuario.UsuarioLoggeado;
        //            if (usuario != null && sesionesActivas.ContainsKey(usuario.Nombre))
        //            {
        //                if (sesionesActivas[usuario.Nombre] != HttpContext.Current.Session.SessionID)
        //                {
        //                    FormsAuthentication.SignOut();
        //                    SesionUsuario.CerrarSesion();

        //                    HttpContext.Current.Response.Redirect("~/Inicio/inicio_sesion.aspx?mensaje=sesion_reemplazada", false);
        //                    HttpContext.Current.ApplicationInstance.CompleteRequest();
        //                }
        //            }
        //        }
        //    }
        //}
    }


}