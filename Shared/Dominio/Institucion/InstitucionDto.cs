using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Institucion
{
    public class InstitucionDto
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public Guid ProductoId { get; set; }
    }
}
