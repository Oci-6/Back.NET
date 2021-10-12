using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio
{
    public class UsuarioLogin
    {
        [Required]
        public string nombre { get; set; }

    }
}
