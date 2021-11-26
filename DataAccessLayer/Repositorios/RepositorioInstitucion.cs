using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioInstitucion: IRepositorioInstitucion
    {
        private readonly WebAPIContext db;
        private DbSet<TenantInstitucion> entities;

        public RepositorioInstitucion(WebAPIContext _db)
        {
            db = _db;
            entities = db.Set<TenantInstitucion>();
        }

        public void Delete(TenantInstitucion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            db.SaveChanges();
        }

        public TenantInstitucion Get(Guid id)
        {
            return entities.Include(Institucion => Institucion.Producto.Precios).SingleOrDefault(s => s.Id == id);
        } 

        public IEnumerable<TenantInstitucion> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(TenantInstitucion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            db.SaveChanges();
        }

        public void Update(TenantInstitucion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            db.SaveChanges();
        }
    }
}
