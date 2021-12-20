using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Microsoft.AspNetCore.Http;
using Shared.Dominio.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Factura : IBL_Factura
    {
        private readonly IRepositorioFactura repositorio;
        private readonly IRepositorio<Precio> repositorio2;
        private readonly IRepositorioInstitucion repositorioI;
        private readonly IMapper mapper;
        private readonly Guid tenantId;

        public BL_Factura(IRepositorioFactura _repositorio, IRepositorioInstitucion _repositorioI, IRepositorio<Precio> _repositorio2, IMapper _mapper,IHttpContextAccessor contextAccessor)
        {
            var tenantActual = contextAccessor.HttpContext?.Request.Headers["TenantId"];
            if (!string.IsNullOrWhiteSpace(tenantActual))
            {
                tenantId = Guid.Parse(tenantActual);
            }
            else
            {
                tenantId = Guid.Empty;
            }
            repositorio = _repositorio;
            repositorio2 =  _repositorio2;
            repositorioI = _repositorioI;
            mapper = _mapper;
        }

        public FacturaDto AddFactura(Guid tenantId)
        {
            
            var institucion = repositorioI.Get(tenantId);
            var precios = institucion.Producto.Precios.Where(Precio => Precio.Fecha_Validez >= DateTime.Now).OrderBy(Precio => Precio.Fecha_Validez);
            var precio = precios.ToList().First();
            Console.WriteLine(precio);
            if (institucion.Producto == null)
            {
                throw new Exception("La institucion no tiene un producto asociado");
            }
            var factura = new Factura()
            {
                Id = Guid.NewGuid(),
                Fecha_Vencimiento = DateTime.Today.AddMonths(1),
                Importe = precio.Monto,
                Descripcion = institucion.Producto.Nombre,
                TenantInstitucionId = tenantId
            };
            repositorio.Insert(factura);
            return mapper.Map<FacturaDto>(factura);
        }

        public void DeleteFactura(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public FacturaDto GetFactura(Guid id)
        {
            var factura = repositorio.Get(id);
            if (factura != null)
            {
                return mapper.Map<FacturaDto>(factura);
            }
            return null;
        }

        public IEnumerable<FacturaDto> GetFacturas()
        {
            var facturas = repositorio.GetAll(tenantId);
            return mapper.Map<IEnumerable<FacturaDto>>(facturas);
        }

        public void PutFactura(FacturaDto x, Guid id)
        {
            throw new NotImplementedException();
            //var factura = repositorio.Get(id);
            //if (precio != null && factura != null)
            //{
            //    factura.Fecha_Vencimiento = x.Fecha_Vencimiento;
            //}
            
            //repositorio.Update(factura);
        }
    }
}
