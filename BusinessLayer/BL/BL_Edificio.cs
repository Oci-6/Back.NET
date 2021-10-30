using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Edificio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Edificio : IBL_Edificio
    {
        private readonly IRepositorio<Edificio> repositorio;
        private readonly IMapper mapper;

        public BL_Edificio(IRepositorio<Edificio> _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }

        public EdificioDto AddEdificio(EdificioDto x)
        {
            x.Id = Guid.NewGuid();
            var edificio = mapper.Map<Edificio>(x);
            
            repositorio.Insert(edificio);

            return x;
        }

        public void DeleteEdificio(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public EdificioDto GetEdificio(Guid id)
        {
            var edificio = repositorio.Get(id);
            if (edificio != null)
            {
                return mapper.Map<EdificioDto>(edificio);
            }
            return null;
        }

        public IEnumerable<EdificioDto> GetEdificios()
        {
            return mapper.Map<IEnumerable<EdificioDto>>(repositorio.GetAll());
        }

        public void PutEdificio(EdificioDto x, Guid id)
        {
            var edificio = repositorio.Get(id);
            edificio.Latitud = x.Latitud;
            edificio.Longitud = x.Longitud;

            repositorio.Update(edificio);
        }
    }
}
