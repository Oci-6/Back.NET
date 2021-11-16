using Microsoft.AspNetCore.Http;
using Shared.Dominio.Edificio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.Novedades
{
    public class NovedadDto
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public string Imagen { get; set; }

        public DateTime CreadoEn { get; set; }

        public Guid EdificioId { get; set; }

        public EdificioDto Edificio { get; set; }
    }
}
