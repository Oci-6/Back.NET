using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio
{
    public class Usuario
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}
