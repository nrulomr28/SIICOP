using SIICOP_V1._2.Datos.Repositorio;
using System;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.MenuProgramas
{
    public partial class SeleccionPrograma : System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProgramas();
            }
        }

        private void CargarProgramas()
        {
            var repo = new ProgramaRepository();

            rptProgramas.DataSource =
                repo.ObtenerProgramas();

            rptProgramas.DataBind();
        }

        protected void rptProgramas_ItemCommand(
            object source,
            RepeaterCommandEventArgs e)
        {
            int programaId =
                Convert.ToInt32(
                    e.CommandArgument);

            Session["programasID"] =
                programaId;

            int entornoId = 0;

            switch (e.CommandName)
            {
                case "Escolar":
                    entornoId = 2;
                    break;

                case "Comunitario":
                    entornoId = 1;
                    break;
            }

            Response.Redirect(
                $"~/Captura/CapturaReporteActividades.aspx?ValorEntorno={entornoId}");
        }
    }
}