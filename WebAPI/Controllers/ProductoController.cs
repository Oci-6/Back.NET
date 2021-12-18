using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IBL_Producto ibl_Producto;

        public ProductoController(IBL_Producto _producto)
        {
            ibl_Producto = _producto;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductoDto>> GetProductos()
        {
            return Ok(ibl_Producto.GetProductos());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductoDto> Get(Guid id)
        {
            var producto = ibl_Producto.GetProducto(id);

            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        // POST api/<ProductoController>
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]

        public ActionResult Post([FromBody] AgregarProductoDto x)
        {
            return Ok(ibl_Producto.AddProducto(x));
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]

        public ActionResult Put(Guid id, [FromBody] ProductoDto x)
        {
            var producto = ibl_Producto.GetProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            ibl_Producto.PutProducto(x, id);
            return NoContent();
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]

        public ActionResult Delete(Guid id)
        {
            var producto = ibl_Producto.GetProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            ibl_Producto.DeleteProducto(id);
            return NoContent();
        }
    }
}
