using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Microsoft.AspNetCore.Http;
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
        private readonly IRepositorioInstitucion repositorioInstitucion;
        private readonly IMapper mapper;
        private readonly Guid tenantId;


        public BL_Edificio(IRepositorio<Edificio> _repositorio, IRepositorioInstitucion repositorioInstitucion, IHttpContextAccessor contextAccessor, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
            this.repositorioInstitucion = repositorioInstitucion;
            var tenantActual = contextAccessor.HttpContext?.Request.Headers["TenantId"];
            if (!string.IsNullOrWhiteSpace(tenantActual))
            {
                tenantId = Guid.Parse(tenantActual);
            }
            else
            {
                tenantId = Guid.Empty;
            }
        }

        public EdificioDto AddEdificio(EdificioCreateDto x)
        {
            var edificio = mapper.Map<Edificio>(x);
            edificio.Id = Guid.NewGuid();

            var institucion = repositorioInstitucion.Get(tenantId);

            if(institucion.Producto.CantMaxEdificios <= repositorio.GetAll().Count()) {
                throw new Exception("Cantidad de edificios excedida");
            }

            repositorio.Insert(edificio);

            return mapper.Map<EdificioDto>(edificio);
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
            edificio.Nombre = x.Nombre;
            edificio.Latitud = x.Latitud;
            edificio.Longitud = x.Longitud;

            repositorio.Update(edificio);
        }
    }
}
