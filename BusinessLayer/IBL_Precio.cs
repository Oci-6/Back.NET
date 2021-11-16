using Shared.Dominio.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Precio
    {
        PrecioDto AddPrecio(AgregarPrecioDto x);
        IEnumerable<PrecioDto> GetPrecios(Guid id);
        PrecioDto GetPrecio(Guid id);
        void PutPrecio(PrecioDto x, Guid id);
        void DeletePrecio(Guid id);
    }
}
