using BusinessLayer.IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Usuario : IBL_Usuario
    {
        private readonly DataAccessLayer.IDAL.IDAL_Usuario _dal;

        public BL_Usuario(DataAccessLayer.IDAL.IDAL_Usuario dal)
        {
            _dal = dal;
        }

        public Shared.Dominio.Usuario AddUsuario(Shared.Dominio.Usuario x)
        {
            return _dal.AddUsuario(x);
        }

        public List<Shared.Dominio.Usuario> GetUsuarios()
        {
            return _dal.GetUsuarios();
        }
    }
}
