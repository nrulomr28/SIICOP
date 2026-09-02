using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Sesion
{
    public class SesionUsuario
    {
        private const string SesionKey = "SesionUsuario";
        public static UsuarioAutenticado UsuarioLoggeado
        {
            get { return (UsuarioAutenticado)HttpContext.Current.Session[SesionKey]; }
            set { HttpContext.Current.Session[SesionKey] = value; }
        }

        public static bool EstaAutenticado
        {
            get { return UsuarioLoggeado != null; }
        }

        public static void CerrarSesion()
        {
            HttpContext.Current.Session[SesionKey] = null;
        }
    }
}