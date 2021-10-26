using Microsoft.AspNetCore.Mvc;
using Shared.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {

        private readonly BusinessLayer.IBL_Institucion bl;

        public InstitucionController(BusinessLayer.IBL_Institucion _bl)
        {
            bl = _bl;
        }
        // GET: api/<InstitucionController>
        [HttpGet]
        public IEnumerable<InstitucionDto> Get()
        {
            return bl.GetInstituciones();
        }

        //GET api/<InstitucionController>/5
        [HttpGet("{id}")]
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
        public ActionResult Post([FromBody] InstitucionDto x)
        {
            return Ok(bl.AddInstitucion(x));
        }

        // PUT api/<InstitucionController>/{id}
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] InstitucionDto x, Guid id)
        {
            InstitucionDto institucion = bl.GetInstitucion(id);
            if(institucion == null)
            {
                return NotFound();
            }

            bl.PutInstitucion(x,id);

            return NoContent();
        }

        // DELETE api/<InstitucionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            InstitucionDto institucion = bl.GetInstitucion(id);
            if (institucion == null)
            {
                return NotFound();
            }

            bl.DeleteInstitucion(id);

            return NoContent();
        }
    }
}
