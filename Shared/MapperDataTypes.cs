using AutoMapper;
using DataAccessLayer.Entidades;
using Shared.Dominio;
using Shared.Dominio.Acceso;
using Shared.Dominio.Edificio;
using Shared.Dominio.Factura;
using Shared.Dominio.Novedades;
using Shared.Dominio.Pago;
using Shared.Dominio.Precio;
using Shared.Dominio.Producto;
using Shared.Dominio.Puerta;
using Shared.Dominio.Salon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MapperDataTypes : Profile
    {
        public MapperDataTypes()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TenantInstitucion, InstitucionDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Edificio, EdificioDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Puerta, PuertaDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Salon, SalonDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 

            CreateMap<Novedad, NovedadDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<AgregarNovedadDto, Novedad>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Precio, PrecioDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AgregarPrecioDto, Precio>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Producto, ProductoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AgregarProductoDto, Producto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Factura, FacturaDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Pago, PagoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AgregarPagoDto, Pago>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Acceso, AccesoDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
        }
    }
}
