using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.AsignacionPuerta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Gestor, Portero")]
    public class AsignacionPuertaController : ControllerBase
    {
        private readonly IBL_AsignacionPuerta asignacionPuerta;

        public AsignacionPuertaController(IBL_AsignacionPuerta asignacionPuerta)
        {
            this.asignacionPuerta = asignacionPuerta;
        }

        // GET: api/<AsignacionPuertaController>
        [HttpGet("Edificio/{idEdificio}")]
        public ActionResult<IEnumerable<AsignacionPuertaDto>> GetAll(Guid idEdificio)
        {
            return Ok(asignacionPuerta.GetAsignaciones(idEdificio));
        }

        // GET api/<AsignacionPuertaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var res = asignacionPuerta.GetAsignacion(id);

            if(res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        // GET api/<AsignacionPuertaController>/5
        [HttpGet]
        [Authorize(Roles = "Portero")]
        public ActionResult GetActual()
        {
            var res = asignacionPuerta.GetActual();

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        // PUT api/<AsignacionPuertaController>
        [HttpPut]
        [Authorize(Roles = "Portero")]
        public ActionResult DesAsignar()
        {
            try
            {
                asignacionPuerta.DesAsignar();
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST api/<AsignacionPuertaController>
        [HttpPost]
        [Authorize(Roles = "Portero")]
        public ActionResult Post([FromBody] AsignacionPuertaCreateDto x)
        {
            try
            {
                var res = asignacionPuerta.AddAsignacion(x);
                return Ok(); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        // PUT api/<AsignacionPuertaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Portero")]
        public ActionResult Put(Guid id, [FromBody] AsignacionPuertaCreateDto x)
        {
            try
            {
                asignacionPuerta.PutAsignacion(x, id);
                return NoContent();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<AsignacionPuertaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Portero")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                asignacionPuerta.DeleteAsignacion( id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
