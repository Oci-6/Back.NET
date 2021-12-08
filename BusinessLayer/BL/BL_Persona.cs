using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Extensiones;
using DataAccessLayer.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio;
using Shared.Dominio.Persona;
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
    public class BL_Persona : IBL_Persona
    {
        private readonly IMapper mapper;
        private readonly IRepositorioPersona repositorio;
        public BL_Persona(IMapper _mapper, IRepositorioPersona _repositorio)
        {
            mapper = _mapper;
            repositorio = _repositorio;
        }

        public async Task<PersonaDto> AddPersonaAsync(PersonaCreateDto x)
        {
            var user = mapper.Map<Persona>(x);
            user.Id = Guid.NewGuid();


            repositorio.Insert(user);

            if (x.Foto != null)
            {

                var imagenes = new List<Stream>();
                var userIds = new List<string>();
                var urls = new List<string>();
                imagenes.Add(x.Foto.OpenReadStream());
                userIds.Add("all");

                var client = new FCClient("uhu60o2e1q4v5dogdue0s8nb1f", "tq7en8fnmibqgvshsgfv929i4h");
                var result = await client.Faces.RecognizeAsync(userIds, new List<string>(), imagenes, "lab");
                foreach (Photo foto in result.Photos)
                {
                    await client.Tags.SaveAsync(foto.Tags.Select(x => x.TagId).ToArray(), user.Id + "@lab");

                }

                userIds = new List<string>();
                userIds.Add(user.Id + "@lab");
                result = await client.Faces.TrainAsync(userIds);
            }

            return mapper.Map<PersonaDto>(user);


        }

        public void DeletePersona(Guid id)
        {
            var persona = repositorio.Get(id);

            if(persona == null)
            {
                throw new Exception("Persona no encontrada");
            }

            repositorio.Delete(persona);
        }

        public PersonaDto GetPersona(Guid id)
        {
            var persona = repositorio.Get(id);

            if (persona == null)
            {
                throw new Exception("Persona no encontrada");
            }

            return mapper.Map<PersonaDto>(persona);
        }

        public async Task<PaginatedListDto<PersonaDto>> GetPersonasAsync(string query, int page, int skip)
        {


            return mapper.Map<PaginatedListDto<PersonaDto>>(await repositorio.GetAll(query, page, 10));
        }

        public IEnumerable<PersonaDto> GetPersonas()
        {
            return mapper.Map<IEnumerable<PersonaDto>>(repositorio.GetAll());
        }


        public void PutPersona(PersonaCreateDto x, Guid id)
        {
            var persona = repositorio.Get(id);

            if (persona == null)
            {
                throw new Exception("Persona no encontrada");
            }
            persona = mapper.Map<PersonaCreateDto, Persona>(x, persona);

            repositorio.Update(persona);
        }

    }
}

