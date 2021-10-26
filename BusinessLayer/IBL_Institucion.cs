using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Institucion
    {
        Shared.Dominio.InstitucionDto AddInstitucion(Shared.Dominio.InstitucionDto x);
        IEnumerable<Shared.Dominio.InstitucionDto> GetInstituciones();
       Shared.Dominio.InstitucionDto GetInstitucion(Guid id);
        void PutInstitucion(Shared.Dominio.InstitucionDto x, Guid id);
        void DeleteInstitucion(Guid id);
    }
}
