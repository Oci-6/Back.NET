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
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Configuration.GetConnectionString("DbConnection")
                )
            ));


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


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
            services.AddScoped<DataAccessLayer.Repositorios.IRepositorioProducto, DataAccessLayer.Repositorios.RepositorioProducto>();
            services.AddScoped(typeof(DataAccessLayer.Repositorios.IRepositorio<>), typeof(DataAccessLayer.Repositorios.Repositorio<>));

            services.AddScoped<BusinessLayer.IBL_Roles, BusinessLayer.BL.BL_Roles>();
            services.AddScoped<BusinessLayer.IBL_Usuario, BusinessLayer.BL.BL_Usuario>();
            services.AddScoped<BusinessLayer.IBL_Institucion, BusinessLayer.BL.BL_Institucion>();
            services.AddScoped<BusinessLayer.IBL_Edificio, BusinessLayer.BL.BL_Edificio>();
            services.AddScoped<BusinessLayer.IBL_Puerta, BusinessLayer.BL.BL_Puerta>();
            services.AddScoped<BusinessLayer.IBL_Salon, BusinessLayer.BL.BL_Salon>();
            services.AddScoped<BusinessLayer.IBL_Novedad, BusinessLayer.BL.BL_Novedad>();
            services.AddScoped<BusinessLayer.IBL_Producto, BusinessLayer.BL.BL_Producto>();
            services.AddScoped<BusinessLayer.IBL_Precio, BusinessLayer.BL.BL_Precio>();




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
                options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            
            DbIncializador.SeedUsuarios(userManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async(context)=> {
                await context.Response.WriteAsync("No se encontro nada");
            });
        }
    }
}
