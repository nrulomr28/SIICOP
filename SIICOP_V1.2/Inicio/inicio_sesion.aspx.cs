using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Helpers;
using SIICOP_V1._2.Sesion;
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
                // 1. Limpiamos cualquier error previo
                Login.FailureText = string.Empty;

                // 2. Validación de credenciales
                if (!Membership.ValidateUser(Login.UserName, Login.Password))
                {
                    e.Authenticated = false;
                    // Asignamos el mensaje de error para el usuario
                    Login.FailureText = "Usuario o contraseña incorrectos. Verifique sus datos e intente de nuevo.";
                    return;
                }

                if (UsuarioTieneSesionActiva(Login.UserName))
                {
                    e.Authenticated = false;
                    Login.FailureText = "El usuario ya tiene una sesión activa en otro navegador o dispositivo. Cierre esa sesión primero.";
                    return;
                }

                // 3. Autenticación exitosa
                FormsAuthentication.SetAuthCookie(Login.UserName, true);

                using (var ctx = new SIICOPEntities())
                {
                    var usuario = ctx.Personales
                    .Where(x => x.login == Login.UserName)
                    .Select(x => new UsuarioAutenticado
                    {
                        PersonalId = x.Personalid,
                        Nombre = x.Nombre + " " + x.paterno + " " + x.materno,
                        usuario = x.login,
                        DependenciaId = x.DependenciaId,
                        Dependencia = x.Dependencia,
                        AreaTrabajoId = x.cat_areaidarea,
                        AreaTrabajo = x.AreaTrabajo,
                        RolId = x.RolesId,
                        NombreRol = x.RolesNombre
                    })
                    .FirstOrDefault();

                    if (usuario == null)
                    {
                        FormsAuthentication.SignOut();

                        e.Authenticated = false;
                        Login.FailureText = "El usuario está autenticado, pero no existe información asociada a su cuenta.";
                        return;
                    }

                    RegistrarSesionActiva(Login.UserName, Session.SessionID);

                    SesionUsuario.UsuarioLoggeado = usuario;
                }

                RedirectHelper.Redirect(Response, "~/Inicio/Launcher.aspx");
            }
            catch (Exception ex)
            {
                e.Authenticated = false;

                // 4. Manejo de excepciones (Errores de BD, red, etc.)
                // En producción, muestra un mensaje amigable:
                Login.FailureText = "Ocurrió un error en el servidor al intentar iniciar sesión. Intente más tarde.";

                // Para depuración (DEBUG), puedes descomentar la siguiente línea para ver el error real en pantalla:
                // Login.FailureText = "Error del sistema: " + ex.Message;

                System.Diagnostics.Debug.WriteLine("Error crítico en Login: " + ex.Message);
            }
        }
        private bool UsuarioTieneSesionActiva(string userName)
        {
            var sesionesActivas = HttpContext.Current.Application["SesionesActivas"] as Dictionary<string, string>;

            if (sesionesActivas == null)
                return false;

            return sesionesActivas.ContainsKey(userName);
        }

        private void RegistrarSesionActiva(string userName, string sessionId)
        {
            var sesionesActivas = HttpContext.Current.Application["SesionesActivas"] as Dictionary<string, string>;

            if (sesionesActivas == null)
            {
                sesionesActivas = new Dictionary<string, string>();
                HttpContext.Current.Application["SesionesActivas"] = sesionesActivas;
            }

            if (sesionesActivas.ContainsKey(userName))
            {
                sesionesActivas[userName] = sessionId;
            }
            else
            {
                sesionesActivas.Add(userName, sessionId);
            }
        }
        /*  protected void Login_Authenticate(
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
          }*/
    }
}