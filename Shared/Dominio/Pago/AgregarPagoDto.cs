using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Pago
{
    public class AgregarPagoDto
    {  

        public float Monto { get; set; }

        public Guid FacturaId { get; set; }

    }
}
