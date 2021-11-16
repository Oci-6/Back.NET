using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Acceso: IBL_Acceso
    {
        private readonly IRepositorio<Acceso> repositorio;
        private readonly IMapper mapper;
        public BL_Acceso(IRepositorio<Acceso> _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }

        public AccesoDto AddAcceso(AccesoDto x)
        {
            x.Id = Guid.NewGuid();
            var acceso = mapper.Map<Acceso>(x);
            repositorio.Insert(acceso);
            return x;
        }

        public IEnumerable<AccesoDto> GetAccesos(Guid idEdificio)
        {
            return mapper.Map<IEnumerable<AccesoDto>>(repositorio.GetAll().Where(element => element.EdificioId == idEdificio));
        }
    }
}
