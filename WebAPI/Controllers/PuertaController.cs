using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Puerta;
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
    public class PuertaController : ControllerBase
    {
        private readonly IBL_Puerta ibl_Puerta;

        public PuertaController(IBL_Puerta _puerta)
        {
            ibl_Puerta = _puerta;
        }

        // GET: api/<PuertaController>
        [HttpGet("Edificio/{IdEdificio}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<PuertaDto>> GetPuertasEdificio(Guid IdEdificio)
        {
            return Ok(ibl_Puerta.GetPuertas(IdEdificio));
        }

        // GET api/<PuertaController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<PuertaDto> Get(Guid id)
        {
            var puerta = ibl_Puerta.GetPuerta(id);

            if (puerta == null)
            {
                return NotFound();
            }
            return Ok(puerta);
        }

        // POST api/<PuertaController>
        [HttpPost]
        [Authorize(Roles = "Admin, Gestor")]
        public ActionResult Post([FromBody] PuertaDto x)
        {
            return Ok(ibl_Puerta.AddPuerta(x));
        }

        // PUT api/<PuertaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Gestor")]

        public ActionResult Put(Guid id, [FromBody] PuertaDto x)
        {
            var puerta = ibl_Puerta.GetPuerta(id);
            if (puerta == null)
            {
                return NotFound();
            }
            ibl_Puerta.PutPuerta(x, id);
            return NoContent();
        }

        // DELETE api/<PuertaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Gestor")]

        public ActionResult Delete(Guid id)
        {
            var puerta = ibl_Puerta.GetPuerta(id);
            if (puerta == null)
            {
                return NotFound();
            }
            ibl_Puerta.DeletePuerta(id);
            return NoContent();
        }
    }
}
