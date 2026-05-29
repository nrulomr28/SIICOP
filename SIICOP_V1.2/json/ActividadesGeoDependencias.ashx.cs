using Newtonsoft.Json;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;


namespace SIICOP_V1._2.json
{
    /// <summary>
    /// Descripción breve de ActividadesGeoDependencias
    /// </summary>
    public class ActividadesGeoDependencias : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {

            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechaInicial = (context.Request.QueryString["fechaInicial"]) == "" ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(context.Request.QueryString["fechaInicial"]);
            DateTime fechafinal = (context.Request.QueryString["fechafinal"]) == "" ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(context.Request.QueryString["fechafinal"]);
            int ProgramaID = Convert.ToInt32(context.Request.QueryString["ProgramaID"]);
            string Dependencia = context.Request.QueryString["Dependencia"];



            if (ProgramaID == 0)
            {

                var resultadoSinPrograma = ctx.Wv_DatosReportesHistorico
                 .Where(x => (EntityFunctions.TruncateTime(x.fecha) >= EntityFunctions.TruncateTime(fechaInicial) &&
                   EntityFunctions.TruncateTime(x.fecha) <= EntityFunctions.TruncateTime(fechafinal)) && x.Dependencia == Dependencia)
                 .Select(x => new
                 {
                     id = x.programasID,
                     Lat = x.Latitud,
                     Lng = x.Longitud,
                     folio = x.FolioActividad,
                     progra = x.NombrePrograma,
                     subpro = x.NombreSubPrograma,
                     accion = x.AccionesNombre,
                     delecon = x.DelegacionOcoonurbacion,
                     region = x.RegionNombre,
                     zona = x.Zona_Estado,
                     muni = x.MUNICIPIO,
                     personas = x.personal_atendio_actividad,
                     descri = x.descripcion_actividad,
                     hombres = x.TotalHombresAtendidos,
                     mujer = x.TotalMujeresAtendidas,
                     total = x.total_atendidos,
                 }).ToList();
                List<coor> coordenada = new List<coor>();

                foreach (var c in resultadoSinPrograma)
                {
                    Char[] delimiter = { ',', ' ' };
                    String[] substrings = c.Lat.Split(delimiter);


                    try
                    {
                        if (c.Lat != "")
                        {
                            coordenada.Add(new coor()
                            {
                                id = (Int32)c.id,
                                latitud = Convert.ToDouble(c.Lat),
                                longitud = Convert.ToDouble(c.Lng),
                                folio = c.folio,
                                programa = c.progra,
                                subprograma = c.subpro,
                                accion = c.accion,
                                DleConur = c.delecon,
                                region = c.region,
                                Zona = c.zona,
                                Municipios = c.muni,
                                personaAtendio = c.personas,
                                descripcion = c.descri,
                                hombres = (Int32)c.hombres,
                                mujeres = (Int32)c.mujer,
                                total = (Int32)c.total,

                            });
                        }
                    }

                    catch (Exception ex)
                    {
                    }
                };

                string json1 = JsonConvert.SerializeObject(coordenada, Formatting.Indented);
                //string json2 = JsonConvert.SerializeObject(resultadoCasillas, Formatting.Indented);
                context.Response.ContentType = "texto/normal";
                context.Response.Write("{ \"Puntos\": " + json1 + " }");
                //context.Response.Write("{ \"Casillas\": " + json2 + " }");
            }
            else
            {

                var resultadoConPrograma = ctx.Wv_DatosReportesHistorico
             .Where(x => (EntityFunctions.TruncateTime(x.fecha) >= EntityFunctions.TruncateTime(fechaInicial) &&
               EntityFunctions.TruncateTime(x.fecha) <= EntityFunctions.TruncateTime(fechafinal) && x.programasID == ProgramaID && x.Dependencia == Dependencia))
             .Select(x => new
             {
                 id = x.programasID,
                 Lat = x.Latitud,
                 Lng = x.Longitud,
                 folio = x.FolioActividad,
                 progra = x.NombrePrograma,
                 subpro = x.NombreSubPrograma,
                 accion = x.AccionesNombre,
                 delecon = x.DelegacionOcoonurbacion,
                 region = x.RegionNombre,
                 zona = x.Zona_Estado,
                 muni = x.MUNICIPIO,
                 personas = x.personal_atendio_actividad,
                 descri = x.descripcion_actividad,
                 hombres = x.TotalHombresAtendidos,
                 mujer = x.TotalMujeresAtendidas,
                 total = x.total_atendidos,

             }).ToList();
                List<coor> coordenadaProgra = new List<coor>();

                foreach (var c in resultadoConPrograma)
                {
                    Char[] delimiter = { ',', ' ' };
                    String[] substrings = c.Lat.Split(delimiter);


                    try
                    {
                        if (c.Lat != "")
                        {
                            coordenadaProgra.Add(new coor()
                            {
                                id = (Int32)c.id,
                                latitud = Convert.ToDouble(c.Lat),
                                longitud = Convert.ToDouble(c.Lng),
                                folio = c.folio,
                                programa = c.progra,
                                subprograma = c.subpro,
                                accion = c.accion,
                                DleConur = c.delecon,
                                region = c.region,
                                Zona = c.zona,
                                Municipios = c.muni,
                                personaAtendio = c.personas,
                                descripcion = c.descri,
                                hombres = (Int32)c.hombres,
                                mujeres = (Int32)c.mujer,
                                total = (Int32)c.total,

                            });
                        }
                    }

                    catch (Exception ex)
                    {
                    }
                };

                string json33 = JsonConvert.SerializeObject(coordenadaProgra, Formatting.Indented);
                context.Response.ContentType = "texto/normal";
                context.Response.Write("{ \"Puntos\": " + json33 + " }");
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public class coor
        {
            public int id { get; set; }
            public Double latitud { get; set; }
            public Double longitud { get; set; }
            public string folio { get; set; }

            public string programa { get; set; }
            public string subprograma { get; set; }

            public string accion { get; set; }
            public string DleConur { get; set; }
            public string region { get; set; }

            public string Zona { get; set; }

            public string Municipios { get; set; }

            public string personaAtendio { get; set; }

            public string descripcion { get; set; }

            public int mujeres { get; set; }

            public int hombres { get; set; }

            public int total { get; set; }
        }
    }
}