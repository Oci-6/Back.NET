using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Institucion
{
    public class InstitucionCreateDto
    {
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string Rut { get; set; }
        [Required]
        public Guid ProductoId { get; set; }

    }
}
