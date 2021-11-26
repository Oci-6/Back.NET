using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Usuario
{
    public class LoginResult
    {
        public UsuarioDto Usuario { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
