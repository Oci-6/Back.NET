using Shared.Dominio.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Evento
    {
        EventoDto AddEvento(EventoCreateDto x);
        IEnumerable<EventoDto> GetEventos();
        EventoDto GetEvento(Guid id);
        void PutEvento(EventoCreateDto x, Guid id);
        void DeleteEvento(Guid id);
    }
}
