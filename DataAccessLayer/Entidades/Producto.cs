using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Producto: BaseEntity
    {
        public string Nombre { get; set; }

        public int CantMaxEdificios { get; set; }

        public int CantMaxSalones { get; set; }

        public IEnumerable<Precio> Precios { get; set; }
    }
}
