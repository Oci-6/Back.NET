using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Dominio.Email;
using Shared.Dominio.PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Extensiones
{
    public static class ServiceCollection
    {

        public static IServiceCollection AddApiConfiguration(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.Configure<PayPalSetting>(Configuration.GetSection("PayPal"));
            Services.Configure<EmailSettings>(Configuration.GetSection("Email"));

            return Services;
        }
    }
}
