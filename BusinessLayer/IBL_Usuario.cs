using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Usuario
    {

        Task<IdentityResult> AddUsuarioAsync(Shared.Dominio.UsuarioDto x);
        IEnumerable<Shared.Dominio.UsuarioDto> GetUsuarios();
        Task<Shared.Dominio.UsuarioDto> GetUsuarioAsync(string id);
        Task<IdentityResult> PutUsuarioAsync(Shared.Dominio.UsuarioDto x, string id);
        Task<IdentityResult> DeleteUsuarioAsync(string id);
        Task<IEnumerable<String>> GetRolesUsuarioAsync(string id);

    }
}
