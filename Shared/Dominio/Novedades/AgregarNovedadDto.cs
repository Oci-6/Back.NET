using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Dominio.Novedades
{
    public class AgregarNovedadDto
    {
        public string Titulo { get; set; }

        public string Contenido { get; set; }

        [JsonIgnore]
        public string Imagen { get; set; }

        public IFormFile ImagenFile { get; set; }

        public Guid EdificioId { get; set; }



    }
}
