using BusinessLayer;
using DataAccessLayer.Repositorios;
using Quartz;
using Shared.Dominio;
using Shared.Dominio.Institucion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Tasks
{
    public class CrearFacturas : IJob
    {
        private readonly IRepositorioInstitucion repositorio;
        private readonly IBL_Factura ibl_Factura;
        private readonly IBL_Institucion bL_Institucion;
        private readonly IBL_Emails emails;

        public CrearFacturas(IRepositorioInstitucion _repositorio, IBL_Factura _ibl_Factura, IBL_Institucion _bL_Institucion, IBL_Emails emails)
        {
            repositorio = _repositorio;
            ibl_Factura = _ibl_Factura;
            bL_Institucion = _bL_Institucion;
            this.emails = emails;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                IEnumerable<InstitucionDto> instituciones = bL_Institucion.GetInstituciones();

                foreach (var institucion in instituciones)
                {
                    var factura = ibl_Factura.AddFactura(institucion.Id);
                    await emails.EnviarFacturasAsync(factura);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);                
            }
        }
    }
}
