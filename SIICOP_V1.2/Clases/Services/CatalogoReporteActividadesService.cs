using SIICOP.Clases.Repositories;
using SIICOP_V1._2.Clases.DTOs;
using System.Collections.Generic;

namespace SIICOP.Clases.Services
{
    public class CatalogoReporteActividadesService
    {
        private readonly CatalogoReporteActividadesRepository _repository;

        public CatalogoReporteActividadesService()
        {
            _repository = new CatalogoReporteActividadesRepository();
        }

        public List<ComboItemDTO> ObtenerProgramas()
        {
            return _repository.ObtenerProgramas();
        }

        public List<ComboItemDTO> ObtenerMunicipiosPrioridad()
        {
            return _repository.ObtenerMunicipiosPrioridad();
        }

        public List<ComboItemDTO> ObtenerPoblacionIndigena()
        {
            return _repository.ObtenerPoblacionIndigena();
        }

        public List<ComboItemDTO> ObtenerProgramasIstmo()
        {
            return _repository.ObtenerProgramasIstmo();
        }

        public List<ComboItemDTO> ObtenerColoniasPrioridad()
        {
            return _repository.ObtenerColoniasPrioridad();
        }
    }
}