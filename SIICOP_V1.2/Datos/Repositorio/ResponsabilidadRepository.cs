using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class ResponsabilidadRepository
    {
        public List<Cat_ResponsabilidadPrincipal> ObtenerResponsabilidadPorEje(int? dependenciaId, int? ejeId)
        {
            using (var ctx = new SIICOPEntities())
            {
                return ctx.Cat_ResponsabilidadPrincipal
                    .Where(r => r.Cat_DependenciaEje.DependenciaId == dependenciaId
                             && r.Cat_DependenciaEje.EjeId == ejeId
                             && r.Habilitado == 1)
                    .OrderBy(r => r.DescripcionResponsabilidad)
                    .ToList();
            }
        }
    }
}