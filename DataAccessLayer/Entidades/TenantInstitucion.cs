using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class TenantInstitucion
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public Producto Producto { get; set; }
        public Guid ProductoId { get; set; }
    }
}
