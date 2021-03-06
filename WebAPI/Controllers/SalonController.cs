using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Dominio.Salon;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Gestor")]
    public class SalonController : ControllerBase
    {
        private readonly IBL_Salon ibl_Salon;

        public SalonController(IBL_Salon _salon)
        {
            ibl_Salon = _salon;
        }

        // GET: api/<SalonController>
        [HttpGet("Edificio/{IdEdificio}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<SalonDto>> GetSalonesEdificio(Guid IdEdificio)
        {
            return Ok(ibl_Salon.GetSalones(IdEdificio));
        }

        // GET api/<SalonController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<SalonDto> Get(Guid id)
        {
            var salon = ibl_Salon.GetSalon(id);

            if (salon == null)
            {
                return NotFound();
            }
            return Ok(salon);
        }

        // POST api/<SalonController>
        [HttpPost]
        public ActionResult Post([FromBody] SalonCreateDto x)
        {
            try
            {
                return Ok(ibl_Salon.AddSalon(x));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<SalonController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] SalonDto x)
        {
            var salon = ibl_Salon.GetSalon(id);
            if (salon == null)
            {
                return NotFound();
            }
            ibl_Salon.PutSalon(x, id);
            return NoContent();
        }

        // DELETE api/<SalonController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var salon = ibl_Salon.GetSalon(id);
            if (salon == null)
            {
                return NotFound();
            }
            ibl_Salon.DeleteSalon(id);
            return NoContent();
        }
    }
}

