using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Edificio : TenantEntity
    {
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
