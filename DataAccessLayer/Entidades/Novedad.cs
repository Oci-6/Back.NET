using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Novedad: BaseEntity
    {
        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public string Imagen { get; set; }

        public Guid EdificioId { get; set; }

        public Edificio Edificio { get; set; }
    }
}
