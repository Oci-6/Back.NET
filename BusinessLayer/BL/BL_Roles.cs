using AutoMapper;
using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Roles: IBL_Roles
    {

        private readonly UserManager<Usuario> userManager;
        private readonly Guid tenantId;
        private readonly IMapper mapper;
        public BL_Roles(UserManager<Usuario> _userManager, IMapper _mapper, IHttpContextAccessor contextAccessor)
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
            mapper = _mapper;

            userManager = _userManager;
        }

        public async Task<IdentityResult> AddRol(UsuarioCreateDto x, string rol)
        {
            var identityResult = await userManager.AddToRoleAsync(await userManager.FindByEmailAsync(x.Email), rol);

            return identityResult;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuariosEnRol(string x)
        {

            var user = await userManager.GetUsersInRoleAsync(x);
            var users = mapper.Map<IEnumerable<UsuarioDto>>(user.Where(element => element.TenantInstitucionId == tenantId || tenantId == Guid.Empty));
            return users;
        }
    }
}
