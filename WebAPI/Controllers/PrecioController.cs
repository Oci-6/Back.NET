using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : ControllerBase
    {
        private readonly IBL_Precio ibl_Precio;

        public PrecioController(IBL_Precio _precio)
        {
            ibl_Precio = _precio;
        }

        // GET: api/<PrecioController>
        [HttpGet("Producto/{idProducto}")]
        public ActionResult<IEnumerable<PrecioDto>> GetPreciosProducto(Guid IdProducto)
        {
            return Ok(ibl_Precio.GetPreciosProducto(IdProducto));
        }
        

        // GET api/<PrecioController>/5
        [HttpGet("{id}")]
        public ActionResult<PrecioDto> Get(Guid id)
        {
            var precio = ibl_Precio.GetPrecio(id);

            if (precio == null)
            {
                return NotFound();
            }
            return Ok(precio);
        }

        // POST api/<PrecioController>
        [HttpPost]
        public ActionResult Post([FromBody] AgregarPrecioDto x)
        {
            return Ok(ibl_Precio.AddPrecio(x));
        }

        // PUT api/<PrecioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] PrecioDto x)
        {
            var precio = ibl_Precio.GetPrecio(id);
            if (precio == null)
            {
                return NotFound();
            }
            ibl_Precio.PutPrecio(x, id);
            return NoContent();
        }

        // DELETE api/<PrecioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var precio = ibl_Precio.GetPrecio(id);
            if (precio == null)
            {
                return NotFound();
            }
            ibl_Precio.DeletePrecio(id);
            return NoContent();
        }
    }
}
