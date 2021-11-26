using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Institucion;
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

        public InstitucionDto AddInstitucion(InstitucionCreateDto x)
        {
            var institucion = mapper.Map<TenantInstitucion>(x);

            institucion.Id = Guid.NewGuid();
            repositorio.Insert(institucion);

            return mapper.Map<InstitucionDto>(institucion);
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

            if (institucion == null)
            {
                throw new ArgumentNullException("Institucion null");
            }

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
