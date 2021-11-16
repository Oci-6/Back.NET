using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Precio
{
    public class PrecioDto
    {
        public Guid Id { get; set; }
        public float Monto { get; set; }
        public DateTime Fecha_Validez { get; set; }

    }
}
