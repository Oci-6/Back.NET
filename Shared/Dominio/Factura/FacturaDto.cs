using Shared.Dominio.Institucion;
using Shared.Dominio.Pago;
using Shared.Dominio.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Factura
{
    public class FacturaDto
    {
        public Guid Id { get; set; }

        public float Importe { get; set; }

        public DateTime Fecha_Vencimiento { get; set; }

        public string Descripcion { get; set; }

        public PagoDto Pago { get; set; }

        public Guid TenantInstitucionId { get; set; }

        public InstitucionDto TenantInstitucion { get; set; }
    }
}
