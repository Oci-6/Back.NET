using DataAccessLayer.Entidades;
using DataAccessLayer.Extensiones;
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
            return entities.Include(ap => ap.Puerta).Include(ap => ap.Usuario).Where(ap => ap.Id == id).SingleOrDefault();
        }
        public AsignacionPuerta GetActual(string idPortero)
        {
            return entities.Include(ap => ap.Puerta).Include(ap => ap.Usuario).Where(ap => ap.UsuarioId == idPortero).OrderByDescending(ap => ap.CreadoEn).FirstOrDefault();
        }

        public IEnumerable<AsignacionPuerta> GetAll(Guid idEdificio)
        {
            return entities.Include(ap => ap.Puerta).Include(ap => ap.Usuario).Where(ap => ap.Puerta.EdificioId == idEdificio).OrderByDescending(ap => ap.CreadoEn).AsEnumerable();
        }
        public async Task<PaginatedList<AsignacionPuerta>> GetPaginatedList(Guid idEdificio, int page, int skip)
        {
            return await PaginatedList<AsignacionPuerta>.CreateAsync(entities.Include(ap => ap.Puerta).Include(ap => ap.Usuario).Where(ap => ap.Puerta.EdificioId == idEdificio).OrderByDescending(ap => ap.CreadoEn).AsQueryable(), page, skip);
        }
    }
}
