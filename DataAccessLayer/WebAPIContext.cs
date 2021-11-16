﻿using DataAccessLayer.Entidades;
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
                        entry.Entity.TenantInstitucion.Id = tenantId;
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
                        entry.Entity.TenantInstitucion.Id = tenantId;
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
                new IdentityRole { Name = "SuperAdmin", NormalizedName = "SuperAdmin".ToUpper() },
                new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Name = "Gestor", NormalizedName = "Gestor".ToUpper() },
                new IdentityRole { Name = "Portero", NormalizedName = "Portero".ToUpper() },
                new IdentityRole { Name = "Persona", NormalizedName = "Persona".ToUpper() });

        }
    }


}
