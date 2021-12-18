using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio.Salon;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.BL
{
    public class BL_Salon : IBL_Salon
    {
        private readonly IRepositorioSalon repositorio;
        private readonly IRepositorioInstitucion repositorioInstitucion;
        private readonly IMapper mapper;
        private readonly Guid tenantId;

        public BL_Salon(IRepositorioSalon _repositorio, IRepositorioInstitucion repositorioInstitucion, IHttpContextAccessor contextAccessor, IMapper _mapper)
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
        public SalonDto AddSalon(SalonCreateDto x)
        {
            var salon = mapper.Map<Salon>(x);
            salon.Id = Guid.NewGuid();

            var institucion = repositorioInstitucion.Get(tenantId);

            if (institucion.Producto.CantMaxSalones <= repositorio.GetAllInstitucion().Count())
            {
                throw new Exception("Cantidad de salones excedida");
            }
            repositorio.Insert(salon);
           
            return mapper.Map<SalonDto>(salon);
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
