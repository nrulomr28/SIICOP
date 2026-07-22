using System;

namespace SIICOP_V1._2.Captura
{
    public partial class Entorno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEscolar_Click(object sender, EventArgs e)
        {
            Session["programasID"] = 0; // temporal
            EnviarDatos(2);
        }

        protected void btnComunitario_Click(object sender, EventArgs e)
        {
            Session["programasID"] = 0; // temporal
            EnviarDatos(1);
        }

        protected void EnviarDatos(int valor)
        {
            Response.Redirect(
            $"~/Captura/CapturaReporteActividades.aspx?ValorEntorno={valor}");
        }

    }
}