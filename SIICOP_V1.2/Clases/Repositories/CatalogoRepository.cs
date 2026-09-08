using SIICOP_V1._2.Clases.DTOs;
using SIICOP_V1._2.Datos;
using System.Collections.Generic;
using System.Linq;

namespace SIICOP_V1._2.Clases.Repositories
{
    public class CatalogoRepository
    {
        public List<MunicipioDto> ObtenerMunicipios()
        {
            using (var db = new SIICOPEntities())
            {
                return db.Municipios
                    .OrderBy(x => x.MUNICIPIO)
                    .Select(x => new MunicipioDto
                    {
                        Id = x.MunicipioID,
                        Clave = x.CLAVE,
                        Nombre = x.MUNICIPIO,
                        DelegacionId = x.DelegacionID,
                        ZonaId = x.ZonaID ?? x.idzona,
                        EsPrioritario = x.prioritario ?? false,
                        EsIndigena = x.p_indigena ?? false,
                        PerteneceAlIstmo = x.programa_istmo ?? false
                    })
                    .ToList();
            }
        }

        public string ObtenerNombrePrograma(int? programaId)
        {
            if (!programaId.HasValue || programaId.Value <= 0)
            {
                return string.Empty;
            }

            using (var db = new SIICOPEntities())
            {
                try
                {
                    var nombre = db.tb_programa
                        .Where(p => p.programasID == programaId.Value)
                        .Select(p => p.NombrePrograma)
                        .FirstOrDefault();

                    return nombre ?? string.Empty;
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error de conexión: {ex.Message}");
                    return string.Empty;
                }
            }
        }
    }
}