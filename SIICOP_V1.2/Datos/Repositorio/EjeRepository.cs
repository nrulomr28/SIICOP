using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class EjeRepository
    {
        public List<Cat_Eje> ObtenerEjesPorDependecia(int? dependenciaId, int entornoId)
        {
            using (var ctx = new SIICOPEntities())
            {
                return ctx.Cat_DependenciaEje
                    .Where(de => de.DependenciaId == dependenciaId
                              && de.Cat_Eje.Habilitado == 1
                              && de.Cat_Eje.EntornoId == entornoId)
                    .Select(de => de.Cat_Eje)
                    .OrderBy(e => e.Eje)
                    .ToList();
            }
        }

        public List<Cat_Eje> ObtenerEjesPorEntorno(int entornoId)
        {
            using (var ctx = new SIICOPEntities())
            {
                return ctx.Cat_Eje
                    .Where(e => e.EntornoId == entornoId
                             && e.Habilitado == 1)
                    .OrderBy(e => e.Eje)
                    .ToList();
            }
        }
    }
}