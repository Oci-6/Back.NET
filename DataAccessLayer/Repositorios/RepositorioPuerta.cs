using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioPuerta : Repositorio<Puerta>, IRepositorioPuerta
    {
        private readonly WebAPIContext db;
        private DbSet<Puerta> entities;

        public RepositorioPuerta(WebAPIContext _db) : base(_db)
        {
            db = _db;
            entities = db.Set<Puerta>();
        }
        public IEnumerable<Puerta> GetAll(Guid idEdificio)
        {
            return entities.Include(p => p.Usuario).Where(p => p.EdificioId == idEdificio).AsEnumerable();
        }

        new public Puerta Get(Guid id)
        {
            return entities.Include(p=> p.Usuario).Where(p => p.Id == id).SingleOrDefault();
        }

        public Puerta GetByPortero(string id)
        {
            return entities.Include(p => p.Usuario).Where(p => p.UsuarioId == id).SingleOrDefault();
        }
    }
}
