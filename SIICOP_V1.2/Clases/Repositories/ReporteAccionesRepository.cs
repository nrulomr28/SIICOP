using SIICOP_V1._2.Clases.DTOs;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SIICOP_V1._2.Clases.Repositories
{
    public class ReporteAccionesBeneficiarios
    {
        public List<TotalAccionesBeneficiadosDto>
            ObtenerReporteBeneficiarios(
                int? mes,
                int? anio)
        {
            using (var ctx = new SIICOPEntities())
            {
                return ctx.Database
                    .SqlQuery<TotalAccionesBeneficiadosDto>(
                        "EXEC usp_acciones_beneficiados @Mes, @Anio",
                        new SqlParameter(
                            "@Mes",
                            (object)mes ?? DBNull.Value),

                        new SqlParameter(
                            "@Anio",
                            (object)anio ?? DBNull.Value)
                    )
                    .ToList();
            }
        }
    }
}