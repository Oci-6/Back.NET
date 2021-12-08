using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class AsignacionPuerta: BaseEntity
    {
        public Guid PuertaId { get; set; }
        public Puerta Puerta { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
