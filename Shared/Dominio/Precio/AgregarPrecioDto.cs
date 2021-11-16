using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Precio
{
    public class AgregarPrecioDto
    {
        public Guid ProductoId { get; set; }
        public float Monto { get; set; }
        public string Fecha_Validez { get; set; }
    }
}
