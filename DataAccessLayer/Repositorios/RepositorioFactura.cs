using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public class RepositorioFactura : Repositorio<Factura>, IRepositorioFactura
    {
        private readonly WebAPIContext db;
        private DbSet<Factura> entities;

        public RepositorioFactura(WebAPIContext _db) : base(_db)
        {
            db = _db;
            entities = db.Set<Factura>();
        }

        public new Factura Get(Guid id)
        {
            return entities.Include(Factura => Factura.Pago).Include(Factura => Factura.TenantInstitucion).SingleOrDefault(s => s.Id == id);
        }

        public new IEnumerable<Factura> GetAll()
        {
            return entities.Include(Factura => Factura.Pago).AsEnumerable();
        }

        public IEnumerable<Factura> GetAll(Guid idTenant)
        {
            return entities.Include(Factura => Factura.Pago).Where(f => f.TenantInstitucionId == idTenant).AsEnumerable();
        }
    }
}
