using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Sesion
{
    public class UsuarioAutenticado
    {
        public int PersonalId { get; set; }
        public string Nombre { get; set; }
        public int? DependenciaId { get; set; }
        public string Dependencia { get; set; }
        public int? AreaTrabajoId { get; set; }
        public string AreaTrabajo { get; set; } = string.Empty;
        public Guid? RolId { get; set; }
        public string NombreRol { get; set; }
    }
}