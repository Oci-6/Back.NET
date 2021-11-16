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
        AccesoDto AddAcceso(AccesoDto x);
        IEnumerable<AccesoDto> GetAccesos(Guid idEdificio);
    }
}
