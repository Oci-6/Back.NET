using AutoMapper;
using DataAccessLayer.Entidades;
using Shared.Dominio;
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
        }
    }
}
