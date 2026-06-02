using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class UbicacionRepository
    {

        public List<tc_zona> ObtenerZonas()
        {

            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.tc_zona.ToList();
                }
            }
            catch (Exception ex)
            {
                // aquí puedes loguear
                throw new Exception("Error al obtener zonas", ex);
            }

        }

        public List<Municipios> ObtenerMunicipiosByZona(int idZona)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Municipios.Where(x => x.idzona == idZona).ToList();
                }
            }
            catch (Exception ex)
            {
                // aquí puedes loguear
                throw new Exception("Error al obtener municipios", ex);
            }

        }

        public List<tc_coordinacion> ObtenerCoordinacionByZona(int idZona)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.tc_coordinacion.Where(x => x.idzona == idZona).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener coordinacion", ex);
            }
        }
       

        public List<Municipios> ObtenerMunicipios()
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Municipios.ToList();
                }
            }
            catch (Exception ex)
            {
                // aquí puedes loguear
                throw new Exception("Error al obtener municipios", ex);
            }
        }

        public bool? ObtenerMunicipiosPrioridad(int municipioId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Municipios
                              .Where(x => x.MunicipioID == municipioId)
                              .Select(x => (bool?)x.prioritario)
                              .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la prioridad del municipio", ex);
            }
        }


        public bool? ObtenerPoblacionIndigena(int municipioId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Municipios
                              .Where(x => x.MunicipioID == municipioId)
                              .Select(x => (bool?)x.p_indigena)
                              .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la prioridad del municipio", ex);
            }
        }


        public bool? ObtenerProgramaISTMO(int municipioId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Municipios
                              .Where(x => x.MunicipioID == municipioId)
                              .Select(x => (bool?)x.programa_istmo)
                              .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la prioridad del municipio", ex);
            }
        }


        public bool? ObtenerColoniasPrioridad(int municipioId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Colonias
                              .Where(x => x.MunicipioID == municipioId)
                              .Select(x => (bool?)x.prioritario)
                              .FirstOrDefault();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error al obtener la prioridad de la colonia", ex);
            }
        }

        public List<Localidades> ObtenerLocalidades(int municipioId)
        {
            try
            {
                using (var ctx = new SIICOPEntities())
                {
                    return ctx.Localidades
                              .Where(x => x.MunicipioID == municipioId)
                              .OrderBy(x => x.Localidad)
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