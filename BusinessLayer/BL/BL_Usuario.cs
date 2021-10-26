using AutoMapper;
using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio;
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

        public BL_Usuario(UserManager<Usuario> _userManager, IMapper _mapper)
        {
            mapper = _mapper;

            userManager = _userManager;
        }

        public async Task<IdentityResult> AddUsuarioAsync(Shared.Dominio.UsuarioDto x)
        {
            var user = mapper.Map<Usuario>(x);
            user.UserName = x.Email;
            IdentityResult identityResult = await userManager.CreateAsync(user, x.Password);
    

            return identityResult;
        }

        public async Task<IdentityResult> DeleteUsuarioAsync(string id)
        {
            return await userManager.DeleteAsync(await userManager.FindByIdAsync(id));
        }

        public async Task<Shared.Dominio.UsuarioDto> GetUsuarioAsync(string id)
        {
            var e = await userManager.FindByIdAsync(id);


            return mapper.Map<Shared.Dominio.UsuarioDto>(e);

        }

        public IEnumerable<Shared.Dominio.UsuarioDto> GetUsuarios()
        {

            var usuarios = mapper.Map<IEnumerable<Shared.Dominio.UsuarioDto>>(userManager.Users);
            return usuarios;
        }

        public async Task<IdentityResult> PutUsuarioAsync(Shared.Dominio.UsuarioDto x, string id)
        {
            var user = await userManager.FindByIdAsync(id);

            //user.Email = x.Email;
            //user.UserName = x.Email;
            //e.Nombre = x.Nombre
            user = mapper.Map<Shared.Dominio.UsuarioDto, Usuario>(x, user);


            return await userManager.UpdateAsync(user);
        }



        public async Task<IEnumerable<string>> GetRolesUsuarioAsync(string id)
        {
            var usuario = await userManager.FindByIdAsync(id);
            return await userManager.GetRolesAsync(usuario);
        }

    }
}
