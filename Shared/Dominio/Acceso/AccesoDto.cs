using Shared.Dominio.Edificio;
using Shared.Dominio.Persona;
using Shared.Dominio.Usuario;
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
        public EdificioDto? Edificio { get; set; }
        public Guid PersonaId { get; set; }
        public PersonaDto? Persona { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
