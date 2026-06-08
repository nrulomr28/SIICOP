using System.Collections.Generic;
using SIICOP_V1._2.Clases.DTOs.SIICOP_V1._2.Models;

namespace SIICOP_V1._2.Servicios.Menus
{
    public static class MenuSysAdmin
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
                    "~/Graficas/Productividad.aspx",
                    "card-success",
                    "#198754"),

                MenuFactory.Crear(
                    "Usuarios",
                    "Administración de cuentas",
                    "fas fa-users-cog",
                    "~/SysAdmin/ControlUser.aspx",
                    "card-warning",
                    "#fd7e14"),

                MenuFactory.Crear(
                    "Roles",
                    "Control de permisos",
                    "fas fa-user-shield",
                    "~/SysAdmin/ControlRoles.aspx",
                    "card-danger",
                    "#dc3545")
            };
        }
    }
}