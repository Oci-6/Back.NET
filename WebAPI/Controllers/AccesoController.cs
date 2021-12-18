using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Usuario;
using Shared.Dominio.Acceso;
using SkyBiometry.Client.FC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Gestor, Portero")]
    public class AccesoController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Acceso acceso;

        public AccesoController(BusinessLayer.IBL_Acceso _acceso)
        {
            acceso = _acceso;
        }
        //GET: api/<AccesoController>/{id}
        [HttpGet("{id}")]
        public ActionResult Get([Required] Guid id)
        {
            var res = acceso.Get(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(acceso.Get(id));
        }

        //GET: api/<AccesoController>
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(acceso.GetAll());
        }

        //GET: api/<AccesoController>/Edificio/{idEdificio}
        [HttpGet("Edificio/{idEdificio}")]
        public async Task<ActionResult> GetEdificiosAsync([Required] Guid idEdificio, [FromQuery] int page = 1, int skip = 10)
        {
            return Ok(await acceso.GetAllEdificioAsync(idEdificio, page, skip));
        }

        //POST: api/<AccesoController>
        [HttpPost]
        [Authorize(Roles = "Portero")]
        public ActionResult Post([FromBody] AccesoCreateDto x)
        {
            return Ok(acceso.AddAcceso(x));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Portero")]
        public ActionResult Put([FromBody]AccesoCreateDto x, [Required] Guid id)
        {
            try
            {
                acceso.PutAcceso(x, id);
                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Portero")]
        public ActionResult Delete([Required] Guid id)
        {
            try
            {
                acceso.DeleteAcceso(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/<AccesoController>/Reconocer
        [HttpPost("Reconocer")]
        [Authorize(Roles = "Portero")]
        public async Task<ActionResult> ReconocerAsync([FromForm] AccesoReconocimientoDto accesoDto)
        {
            var acceso = await this.acceso.ReconocerAsync(accesoDto);
            if (acceso == null)
            {
                return NotFound();
            }
            return Ok(acceso);
        }

       
    }
}
