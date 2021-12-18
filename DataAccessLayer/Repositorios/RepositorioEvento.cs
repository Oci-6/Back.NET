using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioEvento : Repositorio<Evento>, IRepositorioEvento
    {
        private readonly WebAPIContext db;
        private DbSet<Evento> entities;

        public RepositorioEvento(WebAPIContext _db) : base(_db)
        {
            db = _db;
            entities = db.Set<Evento>();
        }
        public new void Insert(Evento entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (Extensiones.Middlewares.InsertEvento(entities,entity))
            {
                throw new Exception("Evento superpuesto con otro");
            }
            entities.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Evento> GetAll(Guid salonId)
        {
            return entities.Where(e => e.SalonId == salonId).AsEnumerable();
        }

    }
}
