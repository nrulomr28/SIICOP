using SIICOP_V1._2.Clases;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace SIICOP_V1._2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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
                        Response.Redirect("~/Error/ErrorAcceso.aspx");
                        return;

                    case 404:
                        Response.Redirect("~/Error/Error404.aspx");
                        return;
                }
            }

            Response.Redirect("~/Error/Error500.aspx");
        }
    }
}