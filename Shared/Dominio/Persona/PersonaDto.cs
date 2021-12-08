using Shared.Dominio.Institucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Persona
{
    public class PersonaDto
    {   
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public Guid? TenantInstitucionId { get; set; }
        public InstitucionDto TenantInstitucion { get; set; }
    }
}
