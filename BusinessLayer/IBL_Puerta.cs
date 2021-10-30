using Shared.Dominio.Puerta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Puerta
    {
        PuertaDto AddPuerta(PuertaDto x);
        IEnumerable<PuertaDto> GetPuertas(Guid id);
        PuertaDto GetPuerta(Guid id);
        void PutPuerta(PuertaDto x, Guid id);
        void DeletePuerta(Guid id);
    }
}
