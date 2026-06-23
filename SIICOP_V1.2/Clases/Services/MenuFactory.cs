
using SIICOP_V1._2.Models;

namespace SIICOP_V1._2.Servicios
{
    public static class MenuFactory
    {
        public static MenuCardDto Crear(
            string titulo,
            string descripcion,
            string icono,
            string url,
            string cssClass,
            string color = null)
        {
            return new MenuCardDto
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Icono = icono,
                Url = url,
                CssClass = cssClass,
                Color = color
            };
        }
    }
}