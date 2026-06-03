
using SIICOP_V1._2.Datos.Repositorio;
using System;

namespace SIICOP_V1._2.MenuProgramas
{
    public partial class SeleccionPrograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProgramas();
            }

        }

        protected void gvProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {

            int programasID = Convert.ToInt32(gvProgramas.SelectedDataKey.Value);

            Session["programasID"] = programasID;

            Response.Redirect("~/Captura/CapturaReporteActividades.aspx");
        }


        protected void CargarProgramas()
        {
            var repo = new ProgramaRepository();

            gvProgramas.DataSource = repo.ObtenerProgramas();
            gvProgramas.DataBind();
        }

    }
}