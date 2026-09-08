using SIICOP_V1._2.Models;
using System.Collections.Generic;


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
                  //  "~/Graficas/Productividad.aspx",
                     "~/VistasReportes/VistaAdmiReportes.aspx",
                    "card-success",
                    "#198754"),

                MenuFactory.Crear(
                    "Usuarios",
                    "Administración de cuentas",
                    "fas fa-users-cog",
                    "~/sysadmin/ControlUser.aspx",
                    "card-warning",
                    "#fd7e14"),

                MenuFactory.Crear(
                    "Roles",
                    "Control de permisos",
                    "fas fa-user-shield",
                    "~/sysadmin/ControlRoles.aspx",
                    "card-danger",
                    "#dc3545"),

                MenuFactory.Crear(
                   "Errores",
                   "Reporte de errores",
                   "fa-solid fa-bug",
                   "~/sysadmin/ErrorLog.aspx",
                   "card-warning",
                   "#fd7e14"),
            };
        }
    }
}