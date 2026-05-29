using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class EntornoRepository
    {

        public List<Cat_Entorno> ObtenerEntorno(int entornoId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Cat_Entorno
                        .Where(x => x.EntornoId == entornoId)
                          //.Where(x => (bool)x.activo)
                          .OrderBy(x => x.Entorno)
                          .ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener entorn", ex);
            }

        }


        public List<Cat_Eje> ObtenerEje(int? entornoId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Cat_Eje
                              .Where(x => x.EntornoId == entornoId)
                              .OrderBy(x => x.Eje)
                              .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener eje", ex);
            }

        }



    }



}