
using SIICOP_V1._2.Captura.DGTSV;
using System;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.MenuProgramas
{
    public partial class MenuDependencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["ImagenSeleccionada"] = null;

                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("CapEjeAtencion"))
                    {

                        PanelEjeAtencion.Visible = true;
                        PanelEjeAtencion.Attributes["class"] = "col-md-6 col-sm-6 text-center contenedor col-md-offset-3";
                        PanelDGPVI.Visible = false;
                    }
                    else if (User.IsInRole("CapDGPVI"))
                    {

                        PanelEjeAtencion.Visible = false;
                        //PanelEjeAtencion.Attributes["class"] = "col-md-6 col-sm-6 text-center contenedor col-md-offset-3";
                        PanelDGPVI.Visible = true;
                    }
                    else
                    {

                        PanelEjeAtencion.Visible = true;
                        PanelEjeAtencion.Attributes["class"] = "col-md-6 col-sm-6 text-center contenedor";
                        PanelDGPVI.Visible = true;
                        PanelDGPVI.Attributes["class"] = "col-md-6 col-sm-6 text-center contenedor";
                    }
                }
                else
                {
                    Response.Redirect("~/Inicio/inicio_sesion.aspx");
                }

            }

        }

       /* protected void lnkbtnDGTVS_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_idetificacion_diaria.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 21;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/DGTSV/Ficha_idetificacion_diaria.aspx");
        }*/

        protected void Imagen_Click(object sender, CommandEventArgs e)
        {
            string opcion = e.CommandArgument?.ToString();

            if (opcion == "Estrategia")
            {
                Session["ImagenSeleccionada"] = true;
                Session["programasID"] = null;

                Response.Redirect(
                    "~/Captura/CapturaReporteActividades.aspx",
                    true);

                return;
            }
            else
            {
                Session["ImagenSeleccionada"] = null;
                Response.Redirect("~/MenuProgramas/SeleccionPrograma.aspx", true);
            }
            /*   if (opcion == "DGPVI")
               {
                   Session["ImagenSeleccionada"] = true;
                   Session["programasID"] = null;

                   Response.Redirect(
                       "~/MenuProgramas/Principal.aspx",
                       true);

                   return;
               }*/

            Session["ImagenSeleccionada"] = null;

            Response.Redirect(
                "~/Captura/Entorno.aspx",
                true);
        }

        
    }


}