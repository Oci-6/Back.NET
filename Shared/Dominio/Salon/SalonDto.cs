using Shared.Dominio.Edificio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Salon
{
    public class SalonDto
    {
        public string Nombre { get; set; }

        public Guid Id { get; set; }

        public Guid EdificioId { get; set; }

        public EdificioDto Edificio { get; set; }
    }
}
