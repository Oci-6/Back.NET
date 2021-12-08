using DataAccessLayer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Extensiones
{
    public class Middlewares
    {
        
        public static bool InsertEvento(DbSet<Evento> eventos, Evento nuevo)
        {
            foreach(Evento evento in eventos)
            {
                if (evento.SalonId == nuevo.SalonId)
                {
                    if (evento.FechaInicio.TimeOfDay >= nuevo.FechaInicio.TimeOfDay && evento.FechaFin.TimeOfDay >= nuevo.FechaInicio.TimeOfDay && evento.FechaInicio.TimeOfDay <= nuevo.FechaFin.TimeOfDay && evento.FechaFin.TimeOfDay <= nuevo.FechaFin.TimeOfDay)
                    {
                        if ((evento.FechaInicio.Date >= nuevo.FechaInicio.Date && evento.FechaFin.Date >= nuevo.FechaInicio.Date && evento.FechaInicio.Date <= nuevo.FechaFin.Date && evento.FechaFin.Date <= nuevo.FechaFin.Date)||( evento.Semanalmente && nuevo.Semanalmente))
                        {
                            if((evento.Domingo == nuevo.Domingo) || (evento.Lunes == nuevo.Lunes) || (evento.Martes == nuevo.Martes) || (evento.Miercoles == nuevo.Miercoles) || (evento.Jueves == nuevo.Jueves) || (evento.Viernes == nuevo.Viernes) || (evento.Sabado == nuevo.Sabado))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        
        }
    }
}
