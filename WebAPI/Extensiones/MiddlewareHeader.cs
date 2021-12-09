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

        public async Task Invoke(HttpContext Context)
        {
        }
    }
}
