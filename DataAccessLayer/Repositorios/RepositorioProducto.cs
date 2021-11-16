using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioProducto : Repositorio<Producto>, IRepositorioProducto
    {
        private readonly WebAPIContext db;
        private DbSet<Producto> entities;

        public RepositorioProducto(WebAPIContext _db): base(_db)
        {
            db = _db;
            entities = db.Set<Producto>();
        }

        public new Producto Get(Guid id)
        {
            return entities.Include(Producto=>Producto.Precios).SingleOrDefault(s => s.Id == id);
        }

        public new IEnumerable<Producto> GetAll()
        {
            return entities.Include(Producto => Producto.Precios).AsEnumerable();
        }
    }
}
