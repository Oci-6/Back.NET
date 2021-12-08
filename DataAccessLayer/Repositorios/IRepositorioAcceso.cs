using DataAccessLayer.Entidades;
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
    }

}
