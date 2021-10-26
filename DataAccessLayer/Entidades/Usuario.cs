using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Usuario: IdentityUser
    {
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Apellido { get; set; }
        public Guid? TenantInstitucionId { get; set; }
        public virtual TenantInstitucion TenantInstitucion { get; set; }
    }

}
