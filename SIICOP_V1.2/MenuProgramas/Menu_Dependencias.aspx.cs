using SIICOP_V1._2.Captura;
using SIICOP_V1._2.Captura.DGTSV;
using System;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.MenuProgramas
{
    public partial class Menu_Dependencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["ImagenSeleccionada"] = null;
            }

        }

        protected void lnkbtnDGTVS_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_idetificacion_diaria.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 21;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/DGTSV/Ficha_idetificacion_diaria.aspx");
        }

        protected void Imagen_Click(object sender, CommandEventArgs e)
        {

            if (e.CommandArgument.Equals("Estrategia"))
            {
                
                Session["ImagenSeleccionada"] = e.CommandArgument;
                Session["programasID"] = null;
                Response.Redirect("~/Captura/CapturaReporteActividades.aspx", true);
            }
            else
            {
              
                Session["ImagenSeleccionada"] = null;
                Response.Redirect("~/MenuProgramas/Principal.aspx", true);
            }

        }

    }


}