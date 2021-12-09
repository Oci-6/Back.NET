using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    [Index(nameof(Email), IsUnique = true)]

    public class Persona : TenantEntity
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
    }
}
