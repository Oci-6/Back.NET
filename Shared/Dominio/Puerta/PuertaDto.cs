using Shared.Dominio.Edificio;
using Shared.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Puerta
{
    public class PuertaDto
    {
        public string Nombre { get; set; }

        public Guid Id { get; set; }

        public Guid EdificioId { get; set; }

        public EdificioDto Edificio { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }

    }
}
