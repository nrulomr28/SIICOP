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
                    "#0d6efd")
            };
        }
    }
}