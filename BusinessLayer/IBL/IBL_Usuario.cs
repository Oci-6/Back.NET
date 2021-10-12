using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IBL
{
    public interface IBL_Usuario
    {

        Shared.Dominio.Usuario AddUsuario(Shared.Dominio.Usuario x);
        List<Shared.Dominio.Usuario> GetUsuarios();

    }
}
