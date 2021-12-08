﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entidades
{
    public class Factura: TenantEntity
    {
        public DateTime Fecha_Vencimiento { get; set; }

        public Pago? Pago { get; set; }

        public float Importe { get; set; }

        public string Descripcion { get; set; }


    }
}
