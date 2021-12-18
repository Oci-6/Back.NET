using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Usuario
{
    public class UsuarioCreateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string TipoDocumento { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]

        public string Documento { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [RegularExpression("[- +()0-9]+")]

        public string PhoneNumber { get; set; }
        public Guid? TenantInstitucionId { get; set; }
    }
}
