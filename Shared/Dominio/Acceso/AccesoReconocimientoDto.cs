using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Acceso
{
    public class AccesoReconocimientoDto
    {

        public Guid EdificioId { get; set; }
        public IFormFile Foto { get; set; }
    }
}
