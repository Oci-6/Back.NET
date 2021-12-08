using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.AsignacionPuerta
{
    public class AsignacionPuertaCreateDto
    {
        [Required]
        public Guid PuertaId { get; set; }

    }
}
