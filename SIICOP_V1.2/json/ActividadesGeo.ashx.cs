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
    /// Descripción breve de ActividadesGeo
    /// </summary>
    public class ActividadesGeo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            int ProgramaID = Convert.ToInt32(context.Request.QueryString["ProgramaID"]);
            int Region = Convert.ToInt32(context.Request.QueryString["Region"]);
            int Tipoconsulta = Convert.ToInt32(context.Request.QueryString["Tipoconsulta"]);
            int IdUser = Convert.ToInt32(context.Request.QueryString["IdUser"]);
            DateTime fechaInicial = (context.Request.QueryString["fechaInicial"]) == "" ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(context.Request.QueryString["fechaInicial"]);
            DateTime fechafinal = (context.Request.QueryString["fechafinal"]) == "" ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(context.Request.QueryString["fechafinal"]);

            string fechainicial = context.Request.QueryString["fechaInicial"];
            string fechaFinal = context.Request.QueryString["fechafinal"];
            if (Tipoconsulta == 0)
            {
                //var ResultadoActGeo = ctx.GetConsulActividades(fechainicial, fechaFinal, "SSP DVI", Region, ProgramaID)
                //    .Select(x =>
                //   new
                //   {
                //       id = x.programasID,
                //       Lat = x.Latitud,
                //       Lng = x.Longitud,
                //       folio = x.FolioActividad,
                //       progra = x.NombrePrograma,
                //       subpro = x.NombreSubPrograma,
                //       accion = x.AccionesNombre,
                //       delecon = x.DelegacionOcoonurbacion,
                //       region = x.RegionNombre,
                //       zona = x.Zona_Estado,
                //       muni = x.MUNICIPIO,
                //       personas = x.personal_atendio_actividad,
                //       descri = x.descripcion_actividad,
                //       hombres = x.TotalHombresAtendidos,
                //       mujer = x.TotalMujeresAtendidas,
                //       total = x.total_atendidos,
                //   }).ToList();
                //List<coor> coordenada = new List<coor>();

                //foreach (var c in ResultadoActGeo)
                //{
                //    Char[] delimiter = { ',', ' ' };
                //    String[] substrings = c.Lat.Split(delimiter);


                //    try
                //    {
                //        if (c.Lat != "")
                //        {
                //            coordenada.Add(new coor()
                //            {
                //                id = (Int32)c.id,
                //                latitud = Convert.ToDouble(c.Lat),
                //                longitud = Convert.ToDouble(c.Lng),
                //                folio = c.folio,
                //                programa = c.progra,
                //                subprograma = c.subpro,
                //                accion = c.accion,
                //                DleConur = c.delecon,
                //                region = c.region,
                //                Zona = c.zona,
                //                Municipios = c.muni,
                //                personaAtendio = c.personas,
                //                descripcion = c.descri,
                //                hombres = (Int32)c.hombres,
                //                mujeres = (Int32)c.mujer,
                //                total = (Int32)c.total,

                //            });
                //        }
                //    }

                //    catch (Exception ex)
                //    {
                //    }
                //};

                //string json1 = JsonConvert.SerializeObject(coordenada, Formatting.Indented);
                //context.Response.ContentType = "texto/normal";
                //context.Response.Write("{ \"Puntos\": " + json1 + " }");
            }
            else
            {
                if (Tipoconsulta == 20)
                {
                    var resultado = ctx.Wv_DatosReportesHistorico
                     .Where(x => (x.Personalid == IdUser)
                            && (EntityFunctions.TruncateTime(x.fecha) >= EntityFunctions.TruncateTime(fechaInicial) &&
                            EntityFunctions.TruncateTime(x.fecha) <= EntityFunctions.TruncateTime(fechafinal)))
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

                    List<coor> coordenadas = new List<coor>();

                    foreach (var c in resultado)
                    {
                        Char[] delimiter = { ',', ' ' };
                        String[] substrings = c.Lat.Split(delimiter);


                        try
                        {
                            if (c.Lat != "")
                            {
                                coordenadas.Add(new coor()
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

                    string json = JsonConvert.SerializeObject(coordenadas, Formatting.Indented);
                    context.Response.ContentType = "texto/normal";
                    context.Response.Write("{ \"Puntos\": " + json + " }");
                }
                else
                {
                    var resultado = ctx.Wv_DatosReportesHistorico
                     .Where(x => (x.programasID == ProgramaID)
                            && (EntityFunctions.TruncateTime(x.fecha) >= EntityFunctions.TruncateTime(fechaInicial) &&
                            EntityFunctions.TruncateTime(x.fecha) <= EntityFunctions.TruncateTime(fechafinal)))
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

                    List<coor> coordenadas = new List<coor>();

                    foreach (var c in resultado)
                    {
                        Char[] delimiter = { ',', ' ' };
                        String[] substrings = c.Lat.Split(delimiter);


                        try
                        {
                            if (c.Lat != "")
                            {
                                coordenadas.Add(new coor()
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

                    string json = JsonConvert.SerializeObject(coordenadas, Formatting.Indented);
                    context.Response.ContentType = "texto/normal";
                    context.Response.Write("{ \"Puntos\": " + json + " }");
                }
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