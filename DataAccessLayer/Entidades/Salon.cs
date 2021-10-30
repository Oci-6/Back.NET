using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Salon: BaseEntity
    {
        public string Nombre { get; set; }

        public Guid EdificioId { get; set; }

        public Edificio Edificio { get; set; }
    }
}
