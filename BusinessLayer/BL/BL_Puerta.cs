﻿using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Puerta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Puerta : IBL_Puerta
    {
        private readonly IRepositorio<Puerta> repositorio;
        private readonly IMapper mapper;

        public BL_Puerta(IRepositorio<Puerta> _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }

        public PuertaDto AddPuerta(PuertaDto x)
        {
            x.Id = Guid.NewGuid();
            var puerta = mapper.Map<Puerta>(x);

            repositorio.Insert(puerta);

            return x;
        }

        public void DeletePuerta(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public PuertaDto GetPuerta(Guid id)
        {
            var puerta = repositorio.Get(id);
            if (puerta != null)
            {
                return mapper.Map<PuertaDto>(puerta);
            }
            return null;
        }

        public IEnumerable<PuertaDto> GetPuertas(Guid idEdificio)
        {
            return mapper.Map<IEnumerable<PuertaDto>>(repositorio.GetAll().Where(element=>element.EdificioId==idEdificio));
        }

        public void PutPuerta(PuertaDto x, Guid id)
        {
            var puerta = repositorio.Get(id);
            puerta.Nombre= x.Nombre;
 
            repositorio.Update(puerta);
        }
    }
}