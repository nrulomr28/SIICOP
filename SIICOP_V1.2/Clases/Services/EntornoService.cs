using System.Web;

namespace SIICOP_V1._2.Clases.Services
{
    public class EntornoService
    {
        private const string SessionKey =
            "ValorEntorno";

        public void GuardarSeleccion(int entornoId)
        {
            HttpContext.Current.Session[SessionKey] =
                entornoId;
        }

        public int? ObtenerSeleccion()
        {
            var valor =
                HttpContext.Current.Session[SessionKey];

            if (valor == null)
                return null;

            return (int)valor;
        }

        public string ObtenerUrlRedireccion(
            int entornoId)
        {
            return $"CapturaReporteActividades?ValorEntorno={entornoId}";
        }
    }
}