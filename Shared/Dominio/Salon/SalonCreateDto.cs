using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Salon
{
    public class SalonCreateDto
    {
        public string Nombre { get; set; }
        public Guid EdificioId { get; set; }

    }
}
