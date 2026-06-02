using SIICOP_V1._2.Clases.Models;
using SIICOP_V1._2.Clases.Services;
using System;

namespace SIICOP_V1._2.Captura
{
    public partial class Entorno : System.Web.UI.Page
    {
        private readonly EntornoService _service =
            new EntornoService();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarSeleccionActual();
            }
        }

        protected void btnEscolar_Click(
            object sender,
            EventArgs e)
        {
            SeleccionarEntorno(
                EntornoConstantes.Escolar);
        }

        protected void btnComunitario_Click(
            object sender,
            EventArgs e)
        {
            SeleccionarEntorno(
                EntornoConstantes.Comunitario);
        }

        private void SeleccionarEntorno(
            int entornoId)
        {
            _service.GuardarSeleccion(
                entornoId);

            Response.Redirect(
                _service.ObtenerUrlRedireccion(
                    entornoId));
        }

        private void MostrarSeleccionActual()
        {
            var entorno =
                _service.ObtenerSeleccion();

            if (!entorno.HasValue)
                return;

            btnEscolar.CssClass =
                "btn btn-primary btn-lg px-5 py-4 me-5";

            btnComunitario.CssClass =
                "btn btn-primary btn-lg px-5 py-4 ms-5";

            if (entorno ==
                EntornoConstantes.Escolar)
            {
                btnEscolar.CssClass =
                    "btn btn-success btn-lg px-5 py-4 me-5";
            }
            else
            {
                btnComunitario.CssClass =
                    "btn btn-success btn-lg px-5 py-4 ms-5";
            }
        }
    }
}