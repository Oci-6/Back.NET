using DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioProducto: IRepositorio<Producto>
    {
        new IEnumerable<Producto> GetAll();
        new Producto Get(Guid id);
    }
}
