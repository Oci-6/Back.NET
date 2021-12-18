using DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioSalon: IRepositorio<Salon>
    {
        IEnumerable<Salon> GetAllInstitucion();
    }
}
