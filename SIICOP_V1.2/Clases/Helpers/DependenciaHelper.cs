
namespace SIICOP_V1._2.Clases.Helpers
{
    public class DependenciaHelper
    {
        public static string ObtenerNombre(int dependenciaId)
        {
            switch (dependenciaId)
            {
                case 1: return "SSP DVI";
                case 2: return "C4";
                case 3: return "DGTSV";
                case 4: return "CEPREVIDE";
                case 5: return "SESCESP";
                case 6: return "DGPRS";
                default: return string.Empty;
            }
        }
    }
}