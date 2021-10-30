using Shared.Dominio.Salon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Salon
    {
        SalonDto AddSalon(SalonDto x);
        IEnumerable<SalonDto> GetSalones(Guid id);
        SalonDto GetSalon(Guid id);
        void PutSalon(SalonDto x, Guid id);
        void DeleteSalon(Guid id);
    }
}
