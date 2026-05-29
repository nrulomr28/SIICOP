using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class ReporteRepository
    {


        public class DTOReporte
        {
            public System.Guid idResumenDiario { get; set; }
            public Nullable<System.DateTime> fecha { get; set; }
            public int Personalid { get; set; }
            public string nombrecompleto { get; set; }
            public Nullable<int> cat_areaidarea { get; set; }
            public string AreaTrabajo { get; set; }
            public string NombrePrograma { get; set; }
            public Nullable<int> programasID { get; set; }
            public Nullable<int> subprogramaId { get; set; }
            public string NombreSubPrograma { get; set; }
            public Nullable<int> AccionesID { get; set; }
            public string AccionesNombre { get; set; }
            public Nullable<int> niños { get; set; }
            public Nullable<int> niñas { get; set; }
            public Nullable<int> hombres { get; set; }
            public Nullable<int> mujeres { get; set; }
            public Nullable<int> docentesH { get; set; }
            public Nullable<int> docentesM { get; set; }
            public Nullable<int> TotalHombresAtendidos { get; set; }
            public Nullable<int> TotalMujeresAtendidas { get; set; }
            public Nullable<int> total_atendidos { get; set; }
            public Nullable<int> RegionID { get; set; }
            public string RegionNombre { get; set; }
            public string DelegacionNombre { get; set; }
            public Nullable<int> DelegacionID { get; set; }
            public string Zona_Estado { get; set; }
            public Nullable<int> ZonaID { get; set; }
            public string MUNICIPIO { get; set; }
            public Nullable<int> MunicipioID { get; set; }
            public string calveMuni { get; set; }
            public string Localidad { get; set; }
            public Nullable<int> LocalidadID { get; set; }
            public string clavelocali { get; set; }
            public string calle { get; set; }
            public string coloni { get; set; }
            public string NombreLugar_Escuela { get; set; }
            public string ClavePlantel { get; set; }
            public string Turno { get; set; }
            public string Nivel { get; set; }
            public string NombreContacto { get; set; }
            public string telcel { get; set; }
            public string Longitud { get; set; }
            public string Latitud { get; set; }
            public string descripcion_actividad { get; set; }
            public string personal_atendio_actividad { get; set; }
            public Nullable<System.DateTime> fechacaptura { get; set; }
            public Nullable<int> fotos { get; set; }
            public string Dependencia { get; set; }
            public string DelegacionOcoonurbacion { get; set; }
            public string FolioActividad { get; set; }
            public Nullable<int> idzona { get; set; }
            public string zona { get; set; }
        }


        public List<DTOReporte> ObtenerDatosReporte(DateTime? fechaInicio, DateTime? fechaFin, string dependencia, int? zona, int? programa, int? municipio, int? localidad, string institucion)
        {
            using (var ctx = new SIICOPEntities())
            {
                var resultado = ctx.Database.SqlQuery<DTOReporte>(
                    "EXEC GetConsulActividades @FechaFinal, @fechaFin, @Dependencia, @Zona, @Programa, @Municipio, @Localidad,@InstitucionesP",
                    new SqlParameter("@FechaFinal", (object)fechaInicio ?? DBNull.Value),
                    new SqlParameter("@fechaFin", (object)fechaFin ?? DBNull.Value),
                    new SqlParameter("@Dependencia", (object)dependencia ?? DBNull.Value),
                    new SqlParameter("@Zona", (object)zona ?? DBNull.Value),
                    new SqlParameter("@Programa", (object)programa ?? DBNull.Value),
                    new SqlParameter("@Municipio", (object)municipio ?? DBNull.Value),
                    new SqlParameter("@Localidad", (object)localidad ?? DBNull.Value),
                    new SqlParameter("@InstitucionesP", (object)institucion ?? DBNull.Value)
                ).ToList();

                return resultado;

            }

        }

    }


}