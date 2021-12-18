using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Extensiones
{
    public class MiddlewareHeader
    {
        private readonly RequestDelegate next;

        public MiddlewareHeader(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Guid tenant;
            var tenantActual = context.Request.Headers["TenantId"];
            if (!string.IsNullOrWhiteSpace(tenantActual))
            {
                tenant = Guid.Parse(tenantActual);
            }
            else
            {
                tenant = Guid.Empty;
            }


            if (next != null && (context.User.IsInRole("SuperAdmin") || (tenant != Guid.Empty && context.User.FindFirst(c => c.Type.Equals("Tenant"))?.Value == tenantActual.ToString())))
            {
                await next(context);
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 401; //UnAuthorized
                await context.Response.WriteAsync("Acceso no permitido");
            }
        }
    }
}
