using AutoMapper;
using DataAccessLayer.Entidades;
using Shared.Dominio;
using Shared.Dominio.Edificio;
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
            CreateMap<Usuario, UsuarioDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<TenantInstitucion, InstitucionDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<Edificio, EdificioDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<Puerta, PuertaDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<Salon, SalonDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
        }
    }
}
