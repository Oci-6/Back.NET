using DataAccessLayer.Entidades;
using DataAccessLayer.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioPersona: IRepositorio<Persona>
    {
        Task<PaginatedList<Persona>> GetAll(string stringQuery, int page, int skip);
        new Persona Get(Guid id);
    }
}
