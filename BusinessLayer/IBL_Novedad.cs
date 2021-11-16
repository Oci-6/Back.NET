using Shared.Dominio.Novedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Novedad
    {
        NovedadDto AddNovedad(AgregarNovedadDto x);
        IEnumerable<NovedadDto> GetNovedades(Guid id);
        NovedadDto GetNovedad(Guid id);
        void PutNovedad(NovedadDto x, Guid id);
        void DeleteNovedad(Guid id);
    }
}
