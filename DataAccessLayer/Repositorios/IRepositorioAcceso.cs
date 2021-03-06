using DataAccessLayer.Entidades;
using DataAccessLayer.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioAcceso : IRepositorio<Acceso>
    {
        IEnumerable<Acceso> GetAllEdificio(Guid idEdificio);
        new IEnumerable<Acceso> GetAll();
        new Acceso Get(Guid id);
        Task<PaginatedList<Acceso>> GetPaginatedList(Guid id, int page, int skip);

    }

}
