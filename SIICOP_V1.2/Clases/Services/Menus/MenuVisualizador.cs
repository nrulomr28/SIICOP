using SIICOP_V1._2.Models;
using System.Collections.Generic;


namespace SIICOP_V1._2.Servicios.Menus
{
    public static class MenuVisualizador
    {
        public static List<MenuCardDto> Obtener()
        {
            return new List<MenuCardDto>
            {
                MenuFactory.Crear(
                    "Productividad",
                    "Consulta de métricas",
                    "fas fa-chart-line",
                    "~/Graficas/Productividad.aspx",
                    "card-success"),

                MenuFactory.Crear(
                    "Informes",
                    "Resultados y seguimiento",
                    "fas fa-file-alt",
                    "~/Graficas/Monitoreo_de_acciones.aspx",
                    "card-primary")
            };
        }
    }
}