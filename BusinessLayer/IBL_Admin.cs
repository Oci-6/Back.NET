using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Admin
    {
        Task<IdentityResult> AddAdminAsync(Shared.Dominio.UsuarioDto x);
        Task<IEnumerable<Shared.Dominio.UsuarioDto>> GetAdminsAsync();
    }
}
