using DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioFactura: IRepositorio<Factura>
    {
        new IEnumerable<Factura> GetAll();
        new Factura Get(Guid id);
    }
}
