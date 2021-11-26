using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace DataAccessLayer
{
    public class WebAPIContext : IdentityDbContext<Usuario>
    {
        private readonly Guid tenantId;
        private readonly ILogger<WebAPIContext> logger;


        public WebAPIContext(DbContextOptions<WebAPIContext> options, IHttpContextAccessor contextAccessor, ILogger<WebAPIContext> _logger)
            : base(options)
        {
            var tenantActual = contextAccessor.HttpContext?.Request.Headers["TenantId"];
            if (!string.IsNullOrWhiteSpace(tenantActual))
            {
                tenantId = Guid.Parse(tenantActual);
            }
            else
            {
                tenantId = Guid.Empty;
            }

            this.Filter<TenantEntity>(f => f.Where(q => q.TenantInstitucion.Id == tenantId));
            logger = _logger;

        }

        public DbSet<TenantInstitucion> Tenants { get; set; }

        public DbSet<Edificio> Edificios { get; set; }
        public DbSet<Puerta> Puertas { get; set; }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Novedad> Novedades { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Evento> Eventos { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        logger.LogInformation("Entidad agregada {Entity}", entry.Entity);
                        break;
                    case EntityState.Modified:
                        logger.LogInformation("Entidad modificada {Entity}", entry.Entity);
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<TenantEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreadoEn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModificadoEn = DateTime.Now;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<TenantEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.TenantInstitucionId = tenantId;
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreadoEn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModificadoEn = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        logger.LogInformation("Entidad agregada {Entity}", entry.Entity);
                        break;
                    case EntityState.Modified:
                        logger.LogInformation("Entidad modificada {Entity}", entry.Entity);
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreadoEn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModificadoEn = DateTime.Now;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<TenantEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.TenantInstitucionId = tenantId;
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasOne(e => e.TenantInstitucion).WithMany();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "21e518a7-885a-4a77-bc7e-f1114b558db2", Name = "SuperAdmin", NormalizedName = "SuperAdmin".ToUpper(), ConcurrencyStamp = "61f97900-cbef-4bad-a9e9-577731359fec" },
                new IdentityRole { Id = "a89ce39c-9185-41ef-90b8-87131ad9f76e", Name = "Admin", NormalizedName = "Admin".ToUpper(), ConcurrencyStamp = "682aa6c7-4c3b-488a-8010-a0f0fddeee2d" },
                new IdentityRole { Id = "28dfc2ec-62ce-4f9f-a0cf-69f2d015f8e2", Name = "Gestor", NormalizedName = "Gestor".ToUpper(), ConcurrencyStamp = "c3603635-9123-45b0-9350-ba86e94d1f81" },
                new IdentityRole { Id = "08d86449-a36f-4e9f-a5c6-b32fae607320", Name = "Portero", NormalizedName = "Portero".ToUpper(), ConcurrencyStamp = "2228e5bf-de4c-40a2-a113-3c069685cfca" },
                new IdentityRole { Id = "01b59239-ff08-4997-b1a3-48d8a8509031", Name = "Persona", NormalizedName = "Persona".ToUpper(), ConcurrencyStamp = "dad4b8e3-868e-4f65-8012-7648226a1706" });

        }
    }


}
