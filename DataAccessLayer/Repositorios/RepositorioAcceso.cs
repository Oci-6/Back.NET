using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioAcceso : Repositorio<Acceso>, IRepositorioAcceso
    {
        private readonly WebAPIContext db;
        private DbSet<Acceso> entities;

        public RepositorioAcceso(WebAPIContext _db) : base(_db)
        {
            db = _db;
            entities = db.Set<Acceso>();
        }

        public IEnumerable<Acceso> GetAllEdificio(Guid idEdificio)
        {
            return entities.Include(Acceso => Acceso.Persona).OrderByDescending(Acceso => Acceso.CreadoEn).Where(Acceso => Acceso.EdificioId == idEdificio).AsEnumerable();
        }

        public new Acceso Get(Guid id)
        {
            return entities.Include(Acceso => Acceso.Persona).SingleOrDefault(s => s.Id == id);
        }

        public new IEnumerable<Acceso> GetAll()
        {
            return entities.Include(Acceso => Acceso.Persona).AsEnumerable();
        }

    }
}
