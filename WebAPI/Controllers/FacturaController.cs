using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio;
using Shared.Dominio.Factura;
using Shared.Dominio.Institucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class FacturaController : ControllerBase
    {
        private readonly IBL_Factura bL_Factura;
        private readonly IBL_Institucion bL_Institucion;

        public FacturaController(IBL_Factura _factura, IBL_Institucion _bL_Institucion)
        {
            bL_Factura = _factura;
            bL_Institucion = _bL_Institucion;
        }

        // GET: api/<FacturaController>
        [HttpGet]

        public ActionResult<IEnumerable<FacturaDto>> Get()
        {
            return Ok(bL_Factura.GetFacturas());
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public ActionResult<FacturaDto> Get(Guid id)
        {
            var factura = bL_Factura.GetFactura(id);

            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        // POST api/<FacturaController>
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Post([FromHeader] Guid tenantId)
        {
            return Ok(bL_Factura.AddFactura(tenantId));
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Put(Guid id, [FromBody] FacturaDto x)
        {
            var factura = bL_Factura.GetFactura(id);
            if (factura == null)
            {
                return NotFound();
            }
            bL_Factura.PutFactura(x, id);
            return NoContent();
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(Guid id)
        {
            var factura = bL_Factura.GetFactura(id);
            if (factura == null)
            {
                return NotFound();
            }
            bL_Factura.DeleteFactura(id);
            return NoContent();
        }

        [HttpGet("CrearFacturas")]
        [Authorize(Roles = "SuperAdmin")]

        public ActionResult CrearFacturas()
        {
            try
            {
                Console.WriteLine("esasfa");
                IEnumerable<InstitucionDto> instituciones = bL_Institucion.GetInstituciones();

                foreach (var institucion in instituciones)
                {
                    bL_Factura.AddFactura(institucion.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;

            }
            return Ok();
        }
    }
}
