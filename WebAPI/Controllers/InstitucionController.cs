using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize(Roles = "SuperAdmin")]

    public class InstitucionController : ControllerBase
    {

        private readonly BusinessLayer.IBL_Institucion bl;

        public InstitucionController(BusinessLayer.IBL_Institucion _bl)
        {
            bl = _bl;
        }
        // GET: api/<InstitucionController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<InstitucionDto> Get()
        {
            return bl.GetInstituciones();
        }

        //GET api/<InstitucionController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<InstitucionDto> Get(Guid id)
        {
            var institucion = bl.GetInstitucion(id);
            if (institucion == null)
            {
                NotFound();
            }
            return Ok(institucion);
        }

        // POST api/<InstitucionController>
        [HttpPost]
        public ActionResult Post([FromBody] InstitucionCreateDto x)
        {
            return Ok(bl.AddInstitucion(x));
        }

        // PUT api/<InstitucionController>/{id}
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] InstitucionDto x, Guid id)
        {
            try
            {
                bl.PutInstitucion(x, id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE api/<InstitucionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                bl.DeleteInstitucion(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
