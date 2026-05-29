using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static SIICOP_V1._2.Datos.Repositorio.ReporteRepository;

namespace SIICOP_V1._2.Datos.Repositorio
{

    public class ReporteAccionesBeneficiarios
    {
        public class DTOReporteAcciones
        {
            public int programasID { get; set; }
            public string NombrePrograma { get; set; }
            public int TotalHombres { get; set; }
            public int TotalMujeres { get; set; }
            public int TotalAtendidos { get; set; }
            public int TotalAcciones { get; set; }
        }



        public List<DTOReporteAcciones> ObtenerReporteBeneficiarios(int? mes, int? anio)
        {
            using (var ctx = new SIICOPEntities())
            {
                var resultado = ctx.Database.SqlQuery<DTOReporteAcciones>(
                    "EXEC usp_acciones_beneficiados @Mes, @Anio",
                    new SqlParameter("@Mes", (object)mes ?? DBNull.Value),
                    new SqlParameter("@Anio", (object)anio ?? DBNull.Value)

                ).ToList();

                return resultado;

            }

        }


    }



}