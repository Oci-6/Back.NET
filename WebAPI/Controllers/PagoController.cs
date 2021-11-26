using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IBL_Pago ibl_Pago;

        public PagoController(IBL_Pago _pago)
        {
            ibl_Pago = _pago;
        }

        // GET: api/<PagoController>
        [HttpGet("Factura/{idFactura}")]
        public ActionResult<IEnumerable<PagoDto>> GetPagoFactura(Guid IdFactura)
        {
            return Ok(ibl_Pago.GetPagoFactura(IdFactura));
        }

        // GET api/<PagoController>/5
        [HttpGet("{id}")]
        public ActionResult<PagoDto> Get(Guid id)
        {
            var pago = ibl_Pago.GetPago(id);

            if (pago == null)
            {
                return NotFound();
            }
            return Ok(pago);
        }

        // POST api/<PagoController>
        [HttpPost]
        public ActionResult Post([FromBody] AgregarPagoDto x)
        {
            return Ok(ibl_Pago.AddPago(x));
        }

        // PUT api/<PagoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] PagoDto x)
        {
            var pago = ibl_Pago.GetPago(id);
            if (pago == null)
            {
                return NotFound();
            }
            ibl_Pago.PutPago(x, id);
            return NoContent();
        }

        // DELETE api/<PagoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var pago = ibl_Pago.GetPago(id);
            if (pago == null)
            {
                return NotFound();
            }
            ibl_Pago.DeletePago(id);
            return NoContent();
        }
    }
}
