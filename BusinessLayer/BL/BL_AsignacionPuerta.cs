using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Microsoft.AspNetCore.Http;
using Shared.Dominio;
using Shared.Dominio.AsignacionPuerta;
using Shared.Dominio.Puerta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_AsignacionPuerta : IBL_AsignacionPuerta
    {
        private readonly IRepositorioAsignacion repositorio;
        private readonly IRepositorioPuerta repositorioPuerta;

        private readonly IMapper mapper;
        private readonly string portero;
        public BL_AsignacionPuerta(IRepositorioAsignacion repositorio, IRepositorioPuerta repositorioPuerta, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            this.repositorio = repositorio;
            this.repositorioPuerta = repositorioPuerta;
            this.mapper = mapper;
            portero = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        }

        public AsignacionPuertaDto AddAsignacion(AsignacionPuertaCreateDto x)
        {
            var puerta = repositorioPuerta.Get(x.PuertaId);

            if (puerta.Usuario != null)
                throw new Exception("Puerta ya asignada");

          

            var asignacion = mapper.Map<AsignacionPuerta>(x);
            asignacion.Id = Guid.NewGuid();
            asignacion.UsuarioId = portero;

            repositorio.Insert(asignacion);

            puerta.UsuarioId = portero;

            repositorioPuerta.Update(puerta);

            return mapper.Map<AsignacionPuertaDto>(asignacion);
        }

        public void DesAsignar()
        {
            var puerta = repositorioPuerta.GetByPortero(portero);

            if (puerta == null)
                throw new Exception("Usuario no asignado");

            puerta.Usuario = null;
            puerta.UsuarioId = null;

            repositorioPuerta.Update(puerta);

        }

        public void DeleteAsignacion(Guid id)
        {
            var asignacion = repositorio.Get(id);

            if (asignacion == null) throw new ArgumentNullException("No existe asignación");

            repositorio.Delete(asignacion);
        }

        public AsignacionPuertaDto GetAsignacion(Guid id)
        {
            return mapper.Map<AsignacionPuertaDto>(repositorio.Get(id));
        }
        public PuertaDto GetActual()
        {
            return mapper.Map<PuertaDto>(repositorioPuerta.GetByPortero(portero));
        }

        public async Task<PaginatedListDto<AsignacionPuertaDto>> GetAsignacionesAsync(Guid id, int take, int skip)
        {
            return mapper.Map<PaginatedListDto<AsignacionPuertaDto>>(await repositorio.GetPaginatedList(id, take, skip));
        }

        public void PutAsignacion(AsignacionPuertaCreateDto x, Guid id)
        {
            var asignacion = repositorio.Get(id);

            if (asignacion == null) throw new ArgumentNullException("No existe asignación");

            asignacion = mapper.Map<AsignacionPuertaCreateDto, AsignacionPuerta>(x, asignacion);


            repositorio.Update(asignacion);
        }

    }
}
