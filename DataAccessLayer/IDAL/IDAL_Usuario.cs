using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IDAL
{
    public interface IDAL_Usuario
    {
        Shared.Dominio.Usuario AddUsuario(Shared.Dominio.Usuario x);
        List<Shared.Dominio.Usuario> GetUsuarios();


    }
}
