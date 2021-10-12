using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Entidades.Usuario> Usuarios { get; set; }

    }

   
}
