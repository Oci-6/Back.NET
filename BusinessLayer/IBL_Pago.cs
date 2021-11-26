using Shared.Dominio.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Pago
    {
        PagoDto AddPago(AgregarPagoDto x);
        IEnumerable<PagoDto> GetPagoFactura(Guid id);
        PagoDto GetPago(Guid id);
        void PutPago(PagoDto x, Guid id);
        void DeletePago(Guid id);
    }
}
