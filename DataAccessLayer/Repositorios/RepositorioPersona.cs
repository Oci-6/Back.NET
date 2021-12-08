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
    public class RepositorioPersona : Repositorio<Persona>, IRepositorioPersona
    {
        private readonly WebAPIContext db;
        private DbSet<Persona> entities;

        public RepositorioPersona(WebAPIContext _db) : base(_db)
        {
            db = _db;
            entities = db.Set<Persona>();
        }

        new public Persona Get(Guid id)
        {
            return entities.Include(p => p.TenantInstitucion).SingleOrDefault(s => s.Id == id);
        }

        public async Task<PaginatedList<Persona>> GetAll(string stringQuery, int page, int skip)
        {
            var query = entities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(stringQuery))
                return await PaginatedList<Persona>.CreateAsync(entities.Where(s => s.Nombre.Contains(stringQuery) || s.Apellido.Contains(stringQuery)), page, skip);
            else
                return await PaginatedList<Persona>.CreateAsync(entities, page, skip);
        }
    }
}
