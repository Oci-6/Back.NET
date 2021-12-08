using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize( Roles = "SuperAdmin, Gestor")]
    public class EventoController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Evento eventos;
        public EventoController(BusinessLayer.IBL_Evento _eventos)
        {
            eventos = _eventos;
        }

        // GET: api/<EventoController>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<EventoDto>> Get()
        {
            return Ok(eventos.GetEventos());
        }

        // GET api/<EventoController>/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult Get(Guid id)
        {
            var evento = eventos.GetEvento(id);
            if (evento != null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // POST api/<EventoController>
        [HttpPost]
        public ActionResult Post([FromBody] EventoCreateDto x)
        {
            try
            {
                var evento = eventos.AddEvento(x);
                return Ok(evento);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EventoController>/{id}
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] EventoCreateDto x)
        {
            if (eventos.GetEvento(id) == null)
            {
                return NotFound();
            }

            eventos.PutEvento(x, id);
            return NoContent();
        }

        // DELETE api/<EventoController>/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (eventos.GetEvento(id) == null)
            {
                return NotFound();
            }

            eventos.DeleteEvento(id);

            return NoContent();
        }
    }
}
