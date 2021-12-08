using DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioPuerta: IRepositorio<Puerta>
    {
        IEnumerable<Puerta> GetAll(Guid idEdificio);
        new Puerta Get(Guid id);
        Puerta GetByPortero(string id);
    }
}
