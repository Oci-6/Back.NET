using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class TenantEntity : BaseEntity
    {
        public TenantInstitucion TenantInstitucion { get; set; }
        public Guid TenantInstitucionId { get; set; }
    }
}
