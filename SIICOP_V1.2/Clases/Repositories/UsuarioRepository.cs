using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Clases.DTOs;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SIICOP_V1._2.Clases.Repositories
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
                .Select(MapearUsuario())
                .ToList();
        }

        public List<UsuarioDto> BuscarUsuarios(string criterio)
        {
            criterio = (criterio ?? string.Empty).Trim();

            var query = _ctx.Personales.AsQueryable();

            if (!string.IsNullOrWhiteSpace(criterio))
            {
                query = query.Where(x =>
                    x.Nombre.Contains(criterio) ||
                    x.paterno.Contains(criterio) ||
                    x.materno.Contains(criterio) ||
                    x.login.Contains(criterio));
            }

            return query
                .OrderBy(x => x.Nombre)
                .Select(MapearUsuario())
                .ToList();
        }

        public Personales ObtenerPorId(int personalId)
        {
            return _ctx.Personales
                .FirstOrDefault(x => x.Personalid == personalId);
        }

        private static System.Linq.Expressions.Expression<Func<Personales, UsuarioDto>> MapearUsuario()
        {
            return x => new UsuarioDto
            {
                PersonalId = x.Personalid,

                NombreCompleto =
                    (x.Nombre ?? "") + " " +
                    (x.paterno ?? "") + " " +
                    (x.materno ?? ""),

                Login = x.login,

                Dependencia = x.Dependencia,

                AreaTrabajo = x.AreaTrabajo,

                FechaCreacion = x.fechacrecion
            };
        }
    }
}