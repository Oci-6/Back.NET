using Shared.Dominio.AsignacionPuerta;
using Shared.Dominio.Puerta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_AsignacionPuerta
    {
        AsignacionPuertaDto AddAsignacion(AsignacionPuertaCreateDto x);
        IEnumerable<AsignacionPuertaDto> GetAsignaciones(Guid id);
        AsignacionPuertaDto GetAsignacion(Guid id);
        PuertaDto GetActual();
        void DesAsignar();
        void PutAsignacion(AsignacionPuertaCreateDto x, Guid id);
        void DeleteAsignacion(Guid id);
    }
}
