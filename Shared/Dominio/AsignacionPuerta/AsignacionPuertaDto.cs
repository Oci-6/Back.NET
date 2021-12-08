using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio.Puerta;
using Shared.Dominio.Usuario;

namespace Shared.Dominio.AsignacionPuerta
{
    public class AsignacionPuertaDto
    {

        public Guid Id { get; set; }
        public Guid PuertaId { get; set; }
        public PuertaDto Puerta { get; set; }
        public string UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
