using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class ProgramaRepository
    {
        public List<tb_programa> ObtenerProgramas()
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.tb_programa
                         .Where(x => (bool)x.activo)
                          .ToList();
                }
            }
            catch (Exception ex)
            {                
                throw new Exception("Error al obtener municipios", ex);
            }

        }


        public List<TB_subprograma> ObtenerSubPrograma(int? programasId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.TB_subprograma
                              .Where(x => x.programasID == programasId)
                              .OrderBy(x => x.NombreSubPrograma)
                              .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener localidades", ex);
            }

        }

        public List<Cat_Acciones> ObtenerAcciones(int subprogramaId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Cat_Acciones
                              .Where(x => x.subprogramaId == subprogramaId)
                              .OrderBy(x => x.AccionesNombre)
                              .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener localidades", ex);
            }

        }


        public List<Cat_SubAcciones> ObtenerSubacciones(int accionesId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Cat_SubAcciones
                              .Where(x => x.AccionesID == accionesId)
                              .OrderBy(x => x.SubAccion)
                              .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener localidades", ex);
            }

        }







    }
}