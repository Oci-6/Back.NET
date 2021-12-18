using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entidades;
using DataAccessLayer.Extensiones;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Extensiones;
using WebAPI.Tasks;

namespace WebAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<WebAPIContext>((options => options
            .UseSqlServer(
                Configuration.GetConnectionString("DbConnectionMauricio")
                )
            ));



            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton(provider => GetScheduler().Result);
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetCoreWebAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                c.OperationFilter<Extensiones.AddRequiredHeaderParameter>(); // Add this here

            });

            services.AddIdentityCore<DataAccessLayer.Entidades.Usuario>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequiredLength = 0;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.User.RequireUniqueEmail = true;
                }
            ).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<WebAPIContext>();
            //Obteniendo Clave Secreta
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Secret"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });

            services.AddCors();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperDataTypes());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);



            // Inyeccion de dependencias

            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioInstitucion, DataAccessLayer.Repositorios.RepositorioInstitucion>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioPersona, DataAccessLayer.Repositorios.RepositorioPersona>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioProducto, DataAccessLayer.Repositorios.RepositorioProducto>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioEvento, DataAccessLayer.Repositorios.RepositorioEvento>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioFactura, DataAccessLayer.Repositorios.RepositorioFactura>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioAcceso, DataAccessLayer.Repositorios.RepositorioAcceso>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioNovedad, DataAccessLayer.Repositorios.RepositorioNovedad>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioAsignacion, DataAccessLayer.Repositorios.RepositorioAsignacion>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioPuerta, DataAccessLayer.Repositorios.RepositorioPuerta>();
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioSalon, DataAccessLayer.Repositorios.RepositorioSalon>();
            services.AddScoped(typeof(DataAccessLayer.Repositorios.IRepositorio<>), typeof(DataAccessLayer.Repositorios.Repositorio<>));

            services.AddScoped<BusinessLayer.IBL_Roles, BusinessLayer.BL.BL_Roles>();
            services.AddScoped<BusinessLayer.IBL_Usuario, BusinessLayer.BL.BL_Usuario>();
            services.AddScoped<BusinessLayer.IBL_Institucion, BusinessLayer.BL.BL_Institucion>();
            services.AddScoped<BusinessLayer.IBL_Edificio, BusinessLayer.BL.BL_Edificio>();
            services.AddScoped<BusinessLayer.IBL_Acceso, BusinessLayer.BL.BL_Acceso>();
            services.AddScoped<BusinessLayer.IBL_Puerta, BusinessLayer.BL.BL_Puerta>();
            services.AddScoped<BusinessLayer.IBL_Salon, BusinessLayer.BL.BL_Salon>();
            services.AddScoped<BusinessLayer.IBL_Novedad, BusinessLayer.BL.BL_Novedad>();
            services.AddScoped<BusinessLayer.IBL_Producto, BusinessLayer.BL.BL_Producto>();
            services.AddScoped<BusinessLayer.IBL_Precio, BusinessLayer.BL.BL_Precio>();
            services.AddScoped<BusinessLayer.IBL_Factura, BusinessLayer.BL.BL_Factura>();
            services.AddScoped<BusinessLayer.IBL_Pago, BusinessLayer.BL.BL_Pago>();
            services.AddScoped<BusinessLayer.IBL_Evento, BusinessLayer.BL.BL_Evento>();
            services.AddScoped<BusinessLayer.IBL_Persona, BusinessLayer.BL.BL_Persona>();
            services.AddScoped<BusinessLayer.IBL_AsignacionPuerta, BusinessLayer.BL.BL_AsignacionPuerta>();
            services.AddScoped<BusinessLayer.IBL_Emails, BusinessLayer.BL.BL_Emails>();

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionScopedJobFactory();

                // Create a "key" for the job
                var jobKey = new JobKey("CrearFacturas");

                // Register the job with the DI container
                q.AddJob<CrearFacturas>(opts => opts.WithIdentity(jobKey));

                // Create a trigger for the job
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("CrearFacturasTrigger")
                                                       .WithCronSchedule("0 0 0 1 * ?")); //Cada primero de mes
                                                                                          //.WithCronSchedule("0 * * * * ?")); //Cada un minuto aprox

            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            services.AddApiConfiguration(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<Usuario> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1")
                );

            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(
                options => options.WithOrigins("http://localhost:4200", "https://www.sandbox.paypal.com/").AllowAnyMethod().AllowAnyHeader()
            );


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseWhen(
                context => !context.Request.Path.StartsWithSegments("/api/Login") && (context.Request.Method.Contains("POST") || context.Request.Method.Contains("PUT") || context.Request.Method.Contains("DELETE")) || (
                (context.Request.Path.StartsWithSegments("/api/Acceso") || context.Request.Path.StartsWithSegments("/api/AsignacionPuerta") || context.Request.Path.StartsWithSegments("/api/Factura") || (context.Request.Path.StartsWithSegments("/api/Pago")&&!context.Request.Path.StartsWithSegments("/api/Pago/Paypal")) || context.Request.Path.StartsWithSegments("/api/Gestor") || context.Request.Path.StartsWithSegments("/api/Portero") || context.Request.Path.StartsWithSegments("/api/Persona")) &&
                context.Request.Method.Contains("GET"))
                ,
                appBuilder =>
                {
                    appBuilder.UseMiddleware<MiddlewareHeader>();
                }
            );


            DbIncializador.SeedUsuarios(userManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("No se encontro nada");
            });
        }



        private async Task<IScheduler> GetScheduler()
        {
            var properties = new NameValueCollection
            {
                { "quartz.scheduler.instanceName", "QuartzWithCore" },
                { "quartz.scheduler.instanceId", "QuartzWithCore" },
                { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
                { "quartz.jobStore.useProperties", "true" },
                { "quartz.jobStore.dataSource", "default" },
                { "quartz.jobStore.tablePrefix", "QRTZ_" },
                {
                    "quartz.dataSource.default.connectionString",
                    "Server=dev\\SQLEXPRESS;Database=Tyson;Trusted_Connection=true;"
                },
                { "quartz.dataSource.default.provider", "SqlServer" },
                { "quartz.threadPool.threadCount", "1" },
                { "quartz.serializer.type", "json" },
            };
            var schedulerFactory = new StdSchedulerFactory(properties);
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();
            return scheduler;
        }



    }
}
