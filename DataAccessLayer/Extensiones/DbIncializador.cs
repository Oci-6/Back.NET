using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Extensiones
{
    public class DbIncializador
    {

        public static void SeedUsuarios(UserManager<Usuario> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                Usuario user = new Usuario()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
                }
            }
        }
    }
}
