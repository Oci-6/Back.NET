using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio.Usuario;

namespace BusinessLayer
{
    public interface IBL_Usuario
    {

        Task<IdentityResult> AddUsuarioAsync(UsuarioCreateDto x);
        IEnumerable<UsuarioDto> GetUsuarios();
        Task<UsuarioDto> GetUsuarioAsync(string id);
        Task<IdentityResult> PutUsuarioAsync(UsuarioDto x, string id);
        Task<IdentityResult> DeleteUsuarioAsync(string id);
        Task<IEnumerable<String>> GetRolesUsuarioAsync(string id);
        Task<UsuarioDto> Login(UsuarioLogin x);

    }
}
