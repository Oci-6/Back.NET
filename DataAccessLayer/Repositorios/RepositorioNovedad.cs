using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioNovedad: Repositorio<Novedad>, IRepositorioNovedad
    {
        private readonly WebAPIContext db;
        private DbSet<Novedad> entities;

        public RepositorioNovedad(WebAPIContext _db) : base(_db)
        {
            db = _db;
            entities = db.Set<Novedad>();
        }

        public IEnumerable<Novedad> GetAll(Guid idEdificio)
        {
            return entities.OrderByDescending(novedad => novedad.CreadoEn).Where(novedad => novedad.EdificioId == idEdificio).AsEnumerable();
        }

        public IEnumerable<Novedad> GetUltimas(Guid tenantId)
        {
            return entities.Include(novedad => novedad.Edificio).Where(novedad => novedad.Edificio.TenantInstitucionId == tenantId).Take(5).OrderByDescending(novedad => novedad.CreadoEn).AsEnumerable();
        }
    }
}
