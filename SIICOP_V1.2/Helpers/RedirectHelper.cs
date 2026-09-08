using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Helpers
{
    public static class RedirectHelper
    {
        public static void Redirect(HttpResponse response, string url)
        {
            response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}