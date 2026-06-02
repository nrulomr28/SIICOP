using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIICOP_V1._2.Clases.DTOs
{
    public class TotalAccionesBeneficiadosDto
    {
        public int ProgramaID { get; set; }
        public string NombrePrograma { get; set; }
        public int TotalHombres { get; set; }
        public int TotalMujeres { get; set; }
        public int TotalAtendidos { get; set; }
        public int TotalAcciones { get; set; }

    }
}