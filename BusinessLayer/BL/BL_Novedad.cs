using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Novedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Novedad : IBL_Novedad
    {
        private readonly IRepositorioNovedad repositorio;
        private readonly IMapper mapper;

        public BL_Novedad(IRepositorioNovedad _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }

        public NovedadDto AddNovedad(AgregarNovedadDto x)
        {
            var nov = new Novedad() { Id = Guid.NewGuid() };
            var novedad = mapper.Map(x, nov);

            repositorio.Insert(novedad);

            return mapper.Map<NovedadDto>(novedad);
        }

        public void DeleteNovedad(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public NovedadDto GetNovedad(Guid id)
        {
            var novedad = repositorio.Get(id);
            if (novedad != null)
            {
                return mapper.Map<NovedadDto>(novedad);
            }
            return null;
        }

        public IEnumerable<NovedadDto> GetNovedades(Guid idEdificio)
        {
            return mapper.Map<IEnumerable<NovedadDto>>(repositorio.GetAll(idEdificio));
        }

        public IEnumerable<NovedadDto> GetUltimas(Guid tenantId)
        {
            return mapper.Map<IEnumerable<NovedadDto>>(repositorio.GetUltimas(tenantId));
        }

        public void PutNovedad(NovedadDto x, Guid id)
        {
            var novedad = repositorio.Get(id);
            novedad.Titulo = x.Titulo;
            novedad.Contenido = x.Contenido;
            

            repositorio.Update(novedad);
        }
    }
}
