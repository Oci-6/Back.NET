using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Evento : IBL_Evento
    {
        private readonly IRepositorioEvento repositorio;
        private readonly IMapper mapper;

        public BL_Evento(IRepositorioEvento _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }
        public EventoDto AddEvento(EventoCreateDto x)
        {
            var evento = mapper.Map<Evento>(x);
            evento.Id = Guid.NewGuid();
            repositorio.Insert(evento);

            return mapper.Map<EventoDto>(evento);
        }

        public void DeleteEvento(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public EventoDto GetEvento(Guid id)
        {
            var evento = repositorio.Get(id);
            if (evento != null)
            {
                return mapper.Map<EventoDto>(evento);
            }
            return null;
        }

        public IEnumerable<EventoDto> GetEventos(Guid salonId)
        {
            return mapper.Map<IEnumerable<EventoDto>>(repositorio.GetAll(salonId));
        }

        public void PutEvento(EventoCreateDto x, Guid id)
        {
            var evento = repositorio.Get(id);
            //evento.Nombre = x.Nombre;
            //evento.FechaInicio = x.FechaInicio;
            //evento.FechaFin = evento.FechaFin;
            //evento.Semanalmente = evento.Semanalmente;
            //evento.Mensualmente = evento.Mensualmente;
            mapper.Map<EventoCreateDto,Evento >(x, evento);

            repositorio.Update(evento);
        }
    }
}
