using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dominio.Institucion;

namespace BusinessLayer
{
    public interface IBL_Institucion
    {
        InstitucionDto AddInstitucion(InstitucionCreateDto x);
        IEnumerable<InstitucionDto> GetInstituciones();
        InstitucionDto GetInstitucion(Guid id);
        void PutInstitucion(InstitucionDto x, Guid id);
        void DeleteInstitucion(Guid id);
    }
}
