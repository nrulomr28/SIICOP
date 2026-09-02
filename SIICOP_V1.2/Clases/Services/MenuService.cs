
using SIICOP_V1._2.Constantes;
using SIICOP_V1._2.Models;
using SIICOP_V1._2.Servicios.Menus;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace SIICOP_V1._2.Servicios
{
    public class MenuService
    {
        public List<MenuCardDto> ObtenerMenuUsuario()
        {
            var cards = new List<MenuCardDto>();

            var roles = Roles.GetRolesForUser();

            if (roles.Contains(RolesSistema.SysAdmin))
            {
                cards.AddRange(MenuSysAdmin.Obtener());
            }

            if (roles.Contains(RolesSistema.Visualizador))
            {
                cards.AddRange(MenuVisualizador.Obtener());
            }

            if (roles.Contains(RolesSistema.CapEjeAtencion))
            {
                cards.AddRange(MenuCapEjeAtencion.Obtener());
            }

            if (roles.Contains(RolesSistema.Administrador))
            {
                cards.AddRange(MenuSysAdmin.Obtener());
            }

            if (roles.Contains(RolesSistema.CapDGPVI))
            {
                cards.AddRange(MenuCapDGPVI.Obtener());
            }

            return cards;
        }
    }
}