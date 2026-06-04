using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.MenuProgramas
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                CargarGrid();

            }

        }

        protected void gvProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {


            int programasID = Convert.ToInt32(gvProgramas.SelectedDataKey.Value);


            Session["programasID"] = programasID;


            Response.Redirect("~/Captura/CapturaReporteActividades.aspx");

        }


        protected void CargarGrid()
        {
            var repo = new ProgramaRepository();

            gvProgramas.DataSource = repo.ObtenerProgramas();
            gvProgramas.DataBind();
        }

    }
}