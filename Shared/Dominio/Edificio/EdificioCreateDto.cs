using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Edificio
{
    public class EdificioCreateDto
    {
        public string Nombre { get; set; }

        public float Latitud { get; set; }

        public float Longitud { get; set; }

        public Guid TenantInstitucionId { get; set; }

    }
}
