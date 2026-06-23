using SIICOP_V1._2.Clases.DTOs;
using SIICOP_V1._2.Clases.Repositories;
using System.Collections.Generic;

namespace SIICOP_V1._2.Clases.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService()
        {
            _repository = new UsuarioRepository();
        }

        public List<UsuarioDto> ObtenerUsuarios()
        {
            return _repository.ObtenerUsuarios();
        }

        public List<UsuarioDto> BuscarUsuarios(string criterio)
        {
            return _repository.BuscarUsuarios(criterio);
        }

        public UsuarioDto ObtenerUsuario(int personalId)
        {
            var usuario = _repository.ObtenerPorId(personalId);

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDto
            {
                PersonalId = usuario.Personalid,

                NombreCompleto =
                    (usuario.Nombre ?? "") + " " +
                    (usuario.paterno ?? "") + " " +
                    (usuario.materno ?? ""),

                Login = usuario.login,

                Dependencia = usuario.Dependencia,

                AreaTrabajo = usuario.AreaTrabajo,

                FechaCreacion = usuario.fechacrecion
            };
        }
    }
}