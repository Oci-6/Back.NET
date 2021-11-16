using Shared.Dominio.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Producto
{
    public class ProductoDto
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public int CantMaxEdificios { get; set; }

        public int CantMaxSalones { get; set; }

        public List<PrecioDto> Precios { get; set; }
    }
}
