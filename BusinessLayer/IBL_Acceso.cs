using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio;
using Shared.Dominio.Acceso;

namespace BusinessLayer
{
    public interface IBL_Acceso
    {
        AccesoDto AddAcceso(AccesoCreateDto x);
        AccesoDto Get(Guid id);
        Task<PaginatedListDto<AccesoDto>> GetAllEdificioAsync(Guid idEdificio, int page, int skip);
        IEnumerable<AccesoDto> GetAll();
        AccesoDto PutAcceso(AccesoCreateDto x, Guid id);
        void DeleteAcceso(Guid id);
        Task<AccesoDto> ReconocerAsync(AccesoReconocimientoDto x);

    }
}
