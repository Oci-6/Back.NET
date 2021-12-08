using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Acceso: BaseEntity
    {
        public Guid EdificioId { get; set; }
        public Edificio Edificio { get; set; }
        public Guid PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
