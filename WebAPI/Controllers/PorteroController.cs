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
    public class PorteroController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Roles roles;
        private readonly BusinessLayer.IBL_Usuario usuarios;

        public PorteroController(BusinessLayer.IBL_Roles roles, BusinessLayer.IBL_Usuario usuarios)
        {
            this.roles = roles;
            this.usuarios = usuarios;
        }
        // GET: api/<PorteroController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get([FromHeader] Guid TenantId)
        {
            return Ok(await roles.GetUsuariosEnRol("Portero"));
        }

        // GET api/<PorteroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> Get([FromHeader] Guid TenantId, string id)
        {
            var usuario = await usuarios.GetUsuarioAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST api/<PorteroController>
        [HttpPost]
        public async Task<ActionResult> Post([FromHeader] Guid TenantId, [FromBody] UsuarioDto x)
        {
            var res = await usuarios.AddUsuarioAsync(x);

            if (res.Succeeded)
            {
                var resRol = await roles.AddRol(x, "Portero");
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

        // PUT api/<PorteroController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromHeader] Guid TenantId, string id, [FromBody] UsuarioDto x)
        {
            var usuario = await usuarios.GetUsuarioAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var res = await usuarios.PutUsuarioAsync(x, id);

            if (res.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE api/<PorteroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromHeader] Guid TenantId, string id)
        {
            var usuario = await usuarios.GetUsuarioAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var res = await usuarios.DeleteUsuarioAsync(id);

            if (res.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
