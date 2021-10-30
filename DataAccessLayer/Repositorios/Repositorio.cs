using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class Repositorio< T >: IRepositorio< T > where T: BaseEntity
    {
        private readonly WebAPIContext db;
        private DbSet<T> entities;

        public Repositorio(WebAPIContext _db)
        {
            db = _db;
            entities = db.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            db.SaveChanges();
        }

        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if( entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
