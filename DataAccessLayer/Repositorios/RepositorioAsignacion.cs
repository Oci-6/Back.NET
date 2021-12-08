using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioAsignacion : Repositorio<AsignacionPuerta>, IRepositorioAsignacion
    {
        private readonly WebAPIContext db;
        private DbSet<AsignacionPuerta> entities;

        public RepositorioAsignacion(WebAPIContext _db) : base(_db)
        {
            db = _db;
            entities = db.Set<AsignacionPuerta>();
        }

        new public AsignacionPuerta Get(Guid id)
        {
            return entities.Include(ap => ap.Puerta).Include(ap => ap.Usuario).Where(ap => ap.Id == id).OrderByDescending(ap => ap.CreadoEn).SingleOrDefault();
        }
        public AsignacionPuerta GetActual(string idPortero)
        {
            return entities.Include(ap => ap.Puerta).Include(ap => ap.Usuario).Where(ap => ap.UsuarioId == idPortero).OrderByDescending(ap => ap.CreadoEn).FirstOrDefault();
        }

        public IEnumerable<AsignacionPuerta> GetAll(Guid idEdificio)
        {
            return entities.Include(ap => ap.Puerta).Include(ap => ap.Usuario).Where(ap => ap.Puerta.EdificioId == idEdificio).AsEnumerable();
        }
    }
}
