using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Datos.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SIICOP_V1._2.Datos.Repositorio
{
    public class UsuarioRepository
    {
        private readonly SIICOPEntities _ctx;

        public UsuarioRepository()
        {
            _ctx = new SIICOPEntities();
        }

        public List<UsuarioDto> ObtenerUsuarios()
        {
            return _ctx.Personales
                .OrderBy(x => x.Nombre)
                .Select(x => new UsuarioDto
                {
                    PersonalId = x.Personalid,

                    NombreCompleto =
                        x.Nombre + " " +
                        x.paterno + " " +
                        x.materno,

                    Login = x.login,

                    Dependencia = x.Dependencia,

                    AreaTrabajo = x.AreaTrabajo,

                    FechaCreacion =
                        x.fechacrecion.ToString()
                })
                .ToList();
        }

        public Personales ObtenerPorId(int personalId)
        {
            return _ctx.Personales
                .FirstOrDefault(x =>
                    x.Personalid == personalId);
        }
    }
}