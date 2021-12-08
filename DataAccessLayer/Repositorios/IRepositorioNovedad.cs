using DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioNovedad: IRepositorio<Novedad>
    {
         IEnumerable<Novedad> GetAll(Guid idEdificio);
         IEnumerable<Novedad> GetUltimas(Guid tenantId);
    }
}
