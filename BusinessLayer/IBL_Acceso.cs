using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio.Acceso;

namespace BusinessLayer
{
    public interface IBL_Acceso
    {
        AccesoDto AddAcceso(AccesoCreateDto x);
        AccesoDto Get(Guid id);
        IEnumerable<AccesoDto> GetAllEdificio(Guid idEdificio);
        IEnumerable<AccesoDto> GetAll();
        AccesoDto PutAcceso(AccesoCreateDto x, Guid id);
        void DeleteAcceso(Guid id);
        Task<AccesoDto> ReconocerAsync(AccesoReconocimientoDto x);

    }
}
