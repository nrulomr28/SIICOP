using SIICOP_V1._2.Clases.DTOs;
using SIICOP_V1._2.Clases.Repositories;
using System.Collections.Generic;

namespace SIICOP_V1._2.Clases.Services
{
    public class CatalogoService
    {
        private readonly CatalogoRepository _repository;

        public CatalogoService()
        {
            _repository = new CatalogoRepository();
        }

        public List<MunicipioDto> ObtenerMunicipios()
        {
            return _repository.ObtenerMunicipios();
        }

        public string ObtenerNombrePrograma(int? programaId)
        {
            return _repository.ObtenerNombrePrograma(programaId);
        }
    }
}