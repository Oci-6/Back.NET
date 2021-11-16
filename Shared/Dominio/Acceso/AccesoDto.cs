using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Acceso
{
    public class AccesoDto
    {
        public Guid Id { get; set; }
        public Guid EdificioId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
