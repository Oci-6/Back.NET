using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Pago
{
    public class PagoDto
    {
        public Guid Id { get; set; }

        public float Monto { get; set; }

        public Guid FacturaId { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
