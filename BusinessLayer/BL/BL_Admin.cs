using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Admin : IBL_Admin
    {
        private readonly UserManager<Usuario> userManager;

        private readonly IMapper mapper;
        public BL_Admin(UserManager<Usuario> _userManager,  IMapper _mapper)
        {
            mapper = _mapper;
        
            userManager = _userManager;
        }

        public async Task<IdentityResult> AddAdminAsync(UsuarioDto x)
        {
            var identityResult =  await userManager.AddToRoleAsync(await userManager.FindByIdAsync(x.Id), "Admin");
            
            return identityResult;
        }

        public async Task<IEnumerable<Shared.Dominio.UsuarioDto>> GetAdminsAsync()
        {
           
            var admin = await userManager.GetUsersInRoleAsync("Admin");
            var admins = mapper.Map<IEnumerable<Shared.Dominio.UsuarioDto>>(admin);
            return admins;
        }
      
    }
}
