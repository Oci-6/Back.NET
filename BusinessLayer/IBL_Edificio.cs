using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio.Edificio;

namespace BusinessLayer
{
    public interface IBL_Edificio
    {
        EdificioDto AddEdificio(EdificioCreateDto x);
        IEnumerable<EdificioDto> GetEdificios();
        EdificioDto GetEdificio(Guid id);
        void PutEdificio(EdificioDto x, Guid id);
        void DeleteEdificio(Guid id);
    }
}
