using System.Collections.Generic;
using SIICOP_V1._2.Clases.DTOs.SIICOP_V1._2.Models;

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
                    "#0d6efd")
            };
        }
    }
}