using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioSalon: Repositorio<Salon>, IRepositorioSalon
    {
        private readonly WebAPIContext db;
        private DbSet<Salon> entities;
        private readonly Guid tenantId;

        public RepositorioSalon(WebAPIContext _db, IHttpContextAccessor contextAccessor) : base(_db)
        {
            db = _db;
            entities = db.Set<Salon>();

            var tenantActual = contextAccessor.HttpContext?.Request.Headers["TenantId"];
            if (!string.IsNullOrWhiteSpace(tenantActual))
            {
                tenantId = Guid.Parse(tenantActual);
            }
            else
            {
                tenantId = Guid.Empty;
            }
        }

        public IEnumerable<Salon> GetAllInstitucion()
        {
            return entities.Include(p => p.Edificio).Where(p => p.Edificio.TenantInstitucionId == tenantId).AsEnumerable();
        }
    }
}
