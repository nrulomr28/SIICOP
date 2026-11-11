using SIICOP_V1._2.Models;
using System.Collections.Generic;


namespace SIICOP_V1._2.Servicios.Menus
{
    public static class MenuCapEjeAtencion
    {
        public static List<MenuCardDto> Obtener()
        {
            return new List<MenuCardDto>
            {
                MenuFactory.Crear(
                    "Captura",
                    "Registro de actividades",
                    "fas fa-edit",
                    "~/MenuProgramas/MenuDependencias.aspx",
                    "card-primary",
                    "#0d6efd"),

                 MenuFactory.Crear(
                    "Productividad",
                    "Indicadores y métricas",
                    "fas fa-chart-bar",
               //   "~/Graficas/Productividad.aspx",
                    "~/VistasReportes/VistaAdmiReportes.aspx",
                    "card-success",
                    "#198754"),
            };
        }
    }
}