using SIICOP_V1._2.Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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