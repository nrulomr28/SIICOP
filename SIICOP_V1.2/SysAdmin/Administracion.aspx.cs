using SIICOP_V1._2.Clases.Repositories;
using System;

namespace SIICOP_V1._2.sysadmin
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(
    object sender,
    EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            var repo =
                new UsuarioRepository();

            gvUsuarios.DataSource =
                repo.ObtenerUsuarios();

            gvUsuarios.DataBind();

        }
    }
}