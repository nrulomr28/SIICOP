using SIICOP_V1._2.Clases.Repositories;
using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2
{
    public partial class TotalAccionesBeneficiados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int mes = DateTime.Now.Month;
            int anio = DateTime.Now.Year;

            var query = new ReporteAccionesBeneficiarios();
            var datos = query.ObtenerReporteBeneficiarios(mes, anio);
            gvTotalAcciones.DataSource = datos;
            gvTotalAcciones.DataBind();
        }
    }
}