using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class EjeRepository
    {
        public List<Cat_Eje> ObtenerEjesPorDependecia(int? dependenciaId)
        {
            using (var ctx = new SIICOPEntities())
            {
                return ctx.Cat_DependenciaEje
                    .Where(de => de.DependenciaId == dependenciaId
                              && de.Cat_Eje.Habilitado == 1)
                    .Select(de => de.Cat_Eje)
                    .OrderBy(e => e.Eje)
                    .ToList();
            }
        }
    }
}