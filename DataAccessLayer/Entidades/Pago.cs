using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Pago: BaseEntity
    {
        public float Monto { get; set; }

        [Key, ForeignKey("Factura")]
        public Guid FacturaId { get; set; }

    }
}
