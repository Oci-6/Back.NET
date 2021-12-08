using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Acceso
{
    public class AccesoCreateDto
    {
        [Required]
        public Guid EdificioId { get; set; }
        [Required]

        public Guid PersonaId { get; set; }
    }
}
