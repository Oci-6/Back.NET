using DataAccessLayer.Entidades;
using DataAccessLayer.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioAsignacion : IRepositorio<AsignacionPuerta>
    {
        IEnumerable<AsignacionPuerta> GetAll(Guid idEdificio);
        new AsignacionPuerta Get(Guid id);
        AsignacionPuerta GetActual(string idPortero);
        Task<PaginatedList<AsignacionPuerta>> GetPaginatedList(Guid id, int page, int skip);
    }
}
