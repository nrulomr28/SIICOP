using SIICOP_V1._2.Clases.DTOs.SIICOP_V1._2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace SIICOP_V1._2.Servicios
{
    public class MenuService
    {
        public List<MenuCardDto> ObtenerMenuUsuario()
        {
            var roles =
                Roles.GetRolesForUser();

            var cards =
                new List<MenuCardDto>();

            if (roles.Contains("SysAdmin"))
            {
                cards.Add(new MenuCardDto
                {
                    Titulo = "Captura",
                    Descripcion = "Registro de actividades",
                    Icono = "fas fa-edit",
                    Url = "~/MenuProgramas/MenuDependencias.aspx",
                    CssClass = "card-primary",
                    Color = "#0d6efd"
                });

                cards.Add(new MenuCardDto
                {
                    Titulo = "Productividad",
                    Descripcion = "Indicadores y métricas",
                    Icono = "fas fa-chart-bar",
                    Url = "~/Graficas/Productividad.aspx",
                    CssClass = "card-success",
                    Color = "#198754"
                });

                cards.Add(new MenuCardDto
                {
                    Titulo = "Usuarios",
                    Descripcion = "Administración de cuentas",
                    Icono = "fas fa-users-cog",
                    Url = "~/SysAdmin/ControlUser.aspx",
                    CssClass = "card-warning",
                    Color = "#fd7e14"
                });

                cards.Add(new MenuCardDto
                {
                    Titulo = "Roles",
                    Descripcion = "Control de permisos",
                    Icono = "fas fa-user-shield",
                    Url = "~/SysAdmin/ControlRoles.aspx",
                    CssClass = "card-danger",
                    Color = "#dc3545"
                });
            }

            if (roles.Contains("Visualizador"))
            {
                cards.Add(new MenuCardDto
                {
                    Titulo = "Productividad",
                    Descripcion = "Consulta de métricas",
                    Icono = "fas fa-chart-line",
                    Url = "~/Graficas/Productividad.aspx",
                    CssClass = "card-success"
                });

                cards.Add(new MenuCardDto
                {
                    Titulo = "Informes",
                    Descripcion = "Resultados y seguimiento",
                    Icono = "fas fa-file-alt",
                    Url = "~/Graficas/Monitoreo_de_acciones.aspx",
                    CssClass = "card-primary"
                });
            }

            return cards;
        }
    }
}