using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public WebAPIContext(DbContextOptions<WebAPIContext> options, IHttpContextAccessor contextAccessor)
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

            this.Filter<BaseEntity>(f => f.Where(q => q.TenantInstitucion.Id == tenantId));

        }

        public DbSet<TenantInstitucion> Tenants { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.TenantInstitucion.Id = tenantId;
                        entry.Entity.CreadoEn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModificadoEn = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasOne(e => e.TenantInstitucion).WithMany();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "SuperAdmin", NormalizedName = "SuperAdmin".ToUpper() },
                new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Name = "Gestor", NormalizedName = "Gestor".ToUpper() },
                new IdentityRole { Name = "Portero", NormalizedName = "Portero".ToUpper() });

        }
    }


}
