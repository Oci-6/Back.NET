using DataAccessLayer.Entidades;
using DataAccessLayer.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class DAL_Usuario : IDAL_Usuario
    {
        private WebAPIContext _db;
        public DAL_Usuario (WebAPIContext db)
        {
            _db = db;
        }


        public Shared.Dominio.Usuario AddUsuario(Shared.Dominio.Usuario x)
        {
            var usuario = new Usuario()
            {
                id = new Guid(),
                nombre = x.nombre,
                apellido = x.apellido
            };

            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            x.id = usuario.id;

            return x;

        }

        public List<Shared.Dominio.Usuario> GetUsuarios()
        {
            return _db.Usuarios.Select(x => new Shared.Dominio.Usuario()
            {
                id = x.id,
                nombre = x.nombre,
                apellido = x.apellido
            }).ToList();
        }
    }
}
