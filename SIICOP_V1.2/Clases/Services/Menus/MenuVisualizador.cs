using System.Collections.Generic;
using SIICOP_V1._2.Clases.DTOs.SIICOP_V1._2.Models;

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