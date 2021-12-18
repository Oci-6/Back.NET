using Shared.Dominio.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Emails
    {
        Task<dynamic> EnviarFacturasAsync(FacturaDto factura);
        Task<dynamic> EnviarPagoAsync(FacturaDto factura);
    }
}
