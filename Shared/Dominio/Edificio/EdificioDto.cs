using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Edificio
{
    public class EdificioDto
    {
        public Guid Id { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public Guid TenantInstitucionId { get; set; }

    }
}
