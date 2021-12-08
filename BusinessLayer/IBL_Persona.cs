using DataAccessLayer.Extensiones;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio;
using Shared.Dominio.Persona;
using Shared.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Persona
    {
        Task<PersonaDto> AddPersonaAsync(PersonaCreateDto x);
        Task<PaginatedListDto<PersonaDto>> GetPersonasAsync(string query, int page, int skip);
        IEnumerable<PersonaDto> GetPersonas();
        PersonaDto GetPersona(Guid id);
        void PutPersona(PersonaCreateDto x, Guid id);
        void DeletePersona(Guid id);
    }
}
