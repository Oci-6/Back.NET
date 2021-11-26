using AutoMapper;
using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Usuario : IBL_Usuario
    {
        private readonly UserManager<Usuario> userManager;
        private readonly IMapper mapper;
        private readonly Guid tenantId;

        public BL_Usuario(UserManager<Usuario> _userManager, IMapper _mapper, IHttpContextAccessor contextAccessor)
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

        public async Task<IdentityResult> AddUsuarioAsync(UsuarioCreateDto x)
        {
            var user = mapper.Map<Usuario>(x);
            user.Id = Guid.NewGuid().ToString();
            user.UserName = x.Email;
            user.TenantInstitucionId = tenantId != Guid.Empty ? tenantId : user.TenantInstitucionId;
            IdentityResult identityResult = await userManager.CreateAsync(user, x.Password);
    
            return identityResult;
        }

        public async Task<IdentityResult> DeleteUsuarioAsync(string id)
        {
            return await userManager.DeleteAsync(await userManager.FindByIdAsync(id));
        }

        public async Task<UsuarioDto> GetUsuarioAsync(string id)
        {
            var e = await userManager.FindByIdAsync(id);
            if (e.TenantInstitucionId != tenantId && tenantId != Guid.Empty)
            {
                return null;
            }

            return mapper.Map<UsuarioDto>(e);

        }

        public IEnumerable<UsuarioDto> GetUsuarios()
        {
            var usuarios = mapper.Map<IEnumerable<UsuarioDto>>(userManager.Users.Where(element => element.TenantInstitucionId == tenantId || tenantId == Guid.Empty));
            return usuarios;
        }

        public async Task<IdentityResult> PutUsuarioAsync(UsuarioDto x, string id)
        {
            var user = await userManager.FindByIdAsync(id);

            //user.Email = x.Email;
            //user.UserName = x.Email;
            //e.Nombre = x.Nombre
            user = mapper.Map<UsuarioDto, Usuario>(x, user);


            return await userManager.UpdateAsync(user);
        }



        public async Task<IEnumerable<string>> GetRolesUsuarioAsync(string id)
        {
            var usuario = await userManager.FindByIdAsync(id);
            return await userManager.GetRolesAsync(usuario);
        }

    }
}
