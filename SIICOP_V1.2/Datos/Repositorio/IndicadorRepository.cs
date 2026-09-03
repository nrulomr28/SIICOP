using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class IndicadorRepository
    {
        public List<Cat_IndicadorDesempeno> ObtenerIndicadoresPorResponsabilidad(int? responsabilidadId)
        {
            using (var context = new SIICOPEntities())
            {
                var indicadores = context.Cat_IndicadorDesempeno
                    .Where(i => i.ResponsabilidadId == responsabilidadId && i.Habilitado == 1)
                    .ToList();
                return indicadores;
            }
        }
    }
}