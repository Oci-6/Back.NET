using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Factura : BaseEntity
    {
        public DateTime Fecha_Vencimiento { get; set; }

        public Pago? Pago { get; set; }

        public float Importe { get; set; }

        public string Descripcion { get; set; }
        public Guid TenantInstitucionId { get; set; }
        public TenantInstitucion TenantInstitucion { get; set; }


    }
}
