using AutoMapper;
using DataAccessLayer.Entidades;
using Shared.Dominio.Usuario;
using Shared.Dominio.Acceso;
using Shared.Dominio.Edificio;
using Shared.Dominio.Factura;
using Shared.Dominio.Evento;
using Shared.Dominio.Institucion;
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
using Shared.Dominio.Persona;
using DataAccessLayer.Extensiones;
using Shared.Dominio;
using Shared.Dominio.AsignacionPuerta;

namespace Shared
{
    public class MapperDataTypes : Profile
    {
        public MapperDataTypes()
        {
            CreateMap<Usuario, UsuarioDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UsuarioCreateDto, Usuario>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TenantInstitucion, InstitucionDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<InstitucionCreateDto, TenantInstitucion>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

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

            CreateMap<Acceso, AccesoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<AccesoCreateDto, Acceso>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Evento, EventoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<EventoCreateDto, Evento>().ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.FechaInicio.ToLocalTime())).ForMember(dest => dest.FechaFin, opt => opt.MapFrom(src => src.FechaFin.ToLocalTime())).ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Persona, PersonaDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PersonaCreateDto, Persona>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap(typeof(PaginatedList<>), typeof(PaginatedListDto<>));

            CreateMap<AsignacionPuerta, AsignacionPuertaDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AsignacionPuertaCreateDto, AsignacionPuerta>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
