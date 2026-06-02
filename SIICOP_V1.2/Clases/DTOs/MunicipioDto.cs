
namespace SIICOP_V1._2.Clases.DTOs
{
    public class MunicipioDto
    {
        public int Id { get; set; }

        public string Clave { get; set; }

        public string Nombre { get; set; }

        public int? DelegacionId { get; set; }

        public int? ZonaId { get; set; }

        public bool EsPrioritario { get; set; }

        public bool EsIndigena { get; set; }

        public bool PerteneceAlIstmo { get; set; }
    }
}