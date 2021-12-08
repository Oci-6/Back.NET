using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Acceso;
using Shared.Dominio.Usuario;
using SkyBiometry.Client.FC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Acceso : IBL_Acceso
    {
        private readonly IRepositorioAcceso repositorio;
        private readonly IMapper mapper;

        public BL_Acceso(IRepositorioAcceso _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }

        public AccesoDto AddAcceso(AccesoCreateDto x)
        {
            var acceso = mapper.Map<Acceso>(x);
            acceso.Id = Guid.NewGuid();

            repositorio.Insert(acceso);
            return mapper.Map<AccesoDto>(acceso);
        }

        public void DeleteAcceso(Guid id)
        {
            var acceso = repositorio.Get(id);
            if (acceso == null)
            {
                throw new Exception("No existe acceso");
            }

            repositorio.Delete(acceso);
        }

        public AccesoDto Get(Guid id)
        {
            return mapper.Map<AccesoDto>(repositorio.Get(id));
        }

        public IEnumerable<AccesoDto> GetAll()
        {
            return mapper.Map<IEnumerable<AccesoDto>>(repositorio.GetAll());
        }

        public IEnumerable<AccesoDto> GetAllEdificio(Guid idEdificio)
        {
            return mapper.Map<IEnumerable<AccesoDto>>(repositorio.GetAllEdificio(idEdificio));
        }

        public AccesoDto PutAcceso(AccesoCreateDto x, Guid id)
        {
            var acceso = repositorio.Get(id);

            if (acceso == null) throw new ArgumentNullException("No existe asignación");

            acceso = mapper.Map<AccesoCreateDto, Acceso>(x, acceso);


            repositorio.Update(acceso);

            return mapper.Map<AccesoDto>(acceso);
        }

        public async Task<AccesoDto> ReconocerAsync(AccesoReconocimientoDto x)
        {
            var imagenes = new List<Stream>();
            var userIds = new List<string>();
            imagenes.Add(x.Foto.OpenReadStream());
            userIds.Add("all");
            var client = new FCClient("uhu60o2e1q4v5dogdue0s8nb1f", "tq7en8fnmibqgvshsgfv929i4h");
            var result = await client.Faces.RecognizeAsync(userIds, new List<string>(), imagenes, "lab");

            var personas = new List<UsuarioDto>();
            foreach (Photo fotoResult in result.Photos)
            {
                foreach (Tag tag in fotoResult.Tags)
                {
                    var match = tag.Matches.FirstOrDefault(m => m.Confidence >= 75);
                    if (match == null)
                    {
                        return null;
                    }
                    var userId = match.UserId.Split('@').FirstOrDefault();
                    if (userId != null)
                    {

                        var acceso = new Acceso()
                        {
                            Id = Guid.NewGuid(),
                            EdificioId = x.EdificioId,
                            PersonaId = Guid.Parse(userId)
                        };
                        repositorio.Insert(acceso);
                        return mapper.Map<AccesoDto>(acceso);
                    }
                }
            }

            return null;
        }
    }
}
