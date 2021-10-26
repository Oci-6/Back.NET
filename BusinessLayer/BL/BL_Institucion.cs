using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Institucion : IBL_Institucion
    {
        private readonly IRepositorioInstitucion repositorio;
        private readonly IMapper mapper;

        public BL_Institucion(IRepositorioInstitucion _repositorio,IMapper _mapper)
        {
            mapper = _mapper;
            repositorio = _repositorio;
        }

        public InstitucionDto AddInstitucion(InstitucionDto x)
        {
            x.Id = new Guid();
            var institucion = mapper.Map<TenantInstitucion>(x);

            repositorio.Insert(institucion);

            x.Id = institucion.Id;
            return x;
        }


        public IEnumerable<InstitucionDto> GetInstituciones()
        {
            return mapper.Map<IEnumerable<InstitucionDto>>(repositorio.GetAll());
        }

        public void DeleteInstitucion(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public void PutInstitucion(InstitucionDto x, Guid id)
        {
            var institucion = repositorio.Get(id);

            institucion.RazonSocial = x.RazonSocial;
            institucion.Rut = x.Rut;



            repositorio.Update(institucion);

        }

        public InstitucionDto GetInstitucion(Guid id)
        {

            var institucion = repositorio.Get(id);

            if (institucion == null)
            {
                return null;
            }

            return mapper.Map<InstitucionDto>(institucion);
        }
    }
}
