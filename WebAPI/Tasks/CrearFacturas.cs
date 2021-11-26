using BusinessLayer;
using DataAccessLayer.Repositorios;
using Quartz;
using Shared.Dominio;
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

        public CrearFacturas(IRepositorioInstitucion _repositorio, IBL_Factura _ibl_Factura, IBL_Institucion _bL_Institucion)
        {
            repositorio = _repositorio;
            ibl_Factura = _ibl_Factura;
            bL_Institucion = _bL_Institucion;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("esasfa");
                IEnumerable<InstitucionDto> instituciones = bL_Institucion.GetInstituciones();

                foreach (var institucion in instituciones)
                {
                    ibl_Factura.AddFactura(institucion.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
                
            }
            return Task.FromResult(0);
        }
    }
}
