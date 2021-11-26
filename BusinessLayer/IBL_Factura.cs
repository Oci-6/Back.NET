using Shared.Dominio.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Factura
    {
        FacturaDto AddFactura(Guid tenantId);
        IEnumerable<FacturaDto> GetFacturas();
        FacturaDto GetFactura(Guid id);
        void PutFactura(FacturaDto x, Guid id);
        void DeleteFactura(Guid id);
    }
}
