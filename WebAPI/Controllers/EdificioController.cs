using BusinessLayer;
using BusinessLayer.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Edificio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EdificioController : ControllerBase
    {
        private readonly IBL_Edificio bL_Edificio;

        public EdificioController(IBL_Edificio _edificio)
        {
            bL_Edificio = _edificio;
        }

        // GET: api/<EdificioController>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<EdificioDto>> Get()
        {
            return Ok(bL_Edificio.GetEdificios());
        }

        // GET api/<EdificioController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<EdificioDto> Get(Guid id)
        {
            var edificio = bL_Edificio.GetEdificio(id);

            if (edificio == null) {
                return NotFound();
            }
            return Ok(edificio);   
        }

        // POST api/<EdificioController>
        [HttpPost]
        public ActionResult Post([FromBody] EdificioCreateDto x)
        {
            try
            {
                return Ok(bL_Edificio.AddEdificio(x));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<EdificioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] EdificioDto x)
        {
            var edificio = bL_Edificio.GetEdificio(id);
            if (edificio == null)
            {
                return NotFound();
            }
            bL_Edificio.PutEdificio(x, id);
            return NoContent();
        }

        // DELETE api/<EdificioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var edificio = bL_Edificio.GetEdificio(id);
            if (edificio == null)
            {
                return NotFound();
            }
            bL_Edificio.DeleteEdificio(id);
            return NoContent();
        }
    }
}
