using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Puerta: BaseEntity
    {
        public string Nombre { get;  set; }
        public Guid EdificioId { get; set; }
        public Edificio Edificio { get; set; }
        public string UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
