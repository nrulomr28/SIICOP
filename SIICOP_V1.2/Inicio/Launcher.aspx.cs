using SIICOP_V1._2.Servicios;
using System;

namespace SIICOP_V1._2.Inicio
{    
        public partial class Launcher : System.Web.UI.Page
        {
            protected void Page_Load(
                object sender,
                EventArgs e)
            {
                if (!IsPostBack)
                {
                    CargarMenu();
                }
            }

            private void CargarMenu()
            {
                var service =
                    new MenuService();

                rptMenu.DataSource =
                    service.ObtenerMenuUsuario();

                rptMenu.DataBind();
            }
        }
    
}