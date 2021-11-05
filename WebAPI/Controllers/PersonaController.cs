using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Roles roles;
        private readonly BusinessLayer.IBL_Usuario usuario;

        public PersonaController(BusinessLayer.IBL_Roles roles, BusinessLayer.IBL_Usuario usuario)
        {
            this.roles = roles;
            this.usuario = usuario;
        }

        //POST: api/<PersonaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromHeader] Guid TenantId,[FromBody] Shared.Dominio.UsuarioDto x)
        {
            x.Id = Guid.NewGuid().ToString();
            x.Password = Guid.NewGuid().ToString();
            var res = await usuario.AddUsuarioAsync(x);
            if (res.Succeeded)
            {
                var resRol = await roles.AddRol(x, "Persona");
                if (resRol.Succeeded)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //GET: api/<AdminController>
        [HttpGet]
        public async Task<IEnumerable<Shared.Dominio.UsuarioDto>> GetAsync([FromHeader] Guid TenantId)
        {
            var users = await roles.GetUsuariosEnRol("Persona");
            return users;
        }

        //GET: api/<PersonaController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Shared.Dominio.UsuarioDto>> GetAsync([FromHeader] Guid TenantId,string id)
        {
            var res = await usuario.GetUsuarioAsync(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        //PUT: api/<PersonaController>/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromHeader] Guid TenantId,[FromBody] Shared.Dominio.UsuarioDto x, string id)
        {
            if ((await usuario.PutUsuarioAsync(x, id)).Succeeded)
            {
                return NoContent();
            }
            return NotFound();
        }
        //DELETE: api/<PersonaController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromHeader] Guid TenantId,string id)
        {
            if ((await usuario.DeleteUsuarioAsync(id)).Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
