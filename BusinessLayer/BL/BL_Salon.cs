using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio.Salon;

namespace BusinessLayer.BL
{
    public class BL_Salon : IBL_Salon
    {
        private readonly IRepositorio<Salon> repositorio;
        private readonly IMapper mapper;

        public BL_Salon(IRepositorio<Salon> _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }
        public SalonDto AddSalon(SalonDto x)
        {
            x.Id = Guid.NewGuid();
            var salon = mapper.Map<Salon>(x);

            repositorio.Insert(salon);

            return x;
        }

        public void DeleteSalon(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public SalonDto GetSalon(Guid id)
        {
            var salon = repositorio.Get(id);
            if (salon != null)
            {
                return mapper.Map<SalonDto>(salon);
            }
            return null;
        }

        public IEnumerable<SalonDto> GetSalones(Guid idEdificio)
        {
            return mapper.Map<IEnumerable<SalonDto>>(repositorio.GetAll().Where(element => element.EdificioId == idEdificio));
        }

        public void PutSalon(SalonDto x, Guid id)
        {
            var salon = repositorio.Get(id);
            salon.Nombre = x.Nombre;

            repositorio.Update(salon);
        }
    }
}
