using System;

namespace SIICOP_V1._2.Clases.DTOs
{
    public class UsuarioDto
    {
        public int PersonalId { get; set; }

        public string NombreCompleto { get; set; }

        public string Login { get; set; }

        public string Dependencia { get; set; }

        public string AreaTrabajo { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
    }
}