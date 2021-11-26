using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Usuario;
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
    public class GestorController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Roles roles;
        private readonly BusinessLayer.IBL_Usuario usuarios;

        public GestorController(BusinessLayer.IBL_Roles roles, BusinessLayer.IBL_Usuario usuarios)
        {
            this.roles = roles;
            this.usuarios = usuarios;
        }
        // GET: api/<GestorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            return Ok(await roles.GetUsuariosEnRol("Gestor"));
        }

        // GET api/<GestorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> Get(string id)
        {
            var usuario = await usuarios.GetUsuarioAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST api/<GestorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreateDto x)
        {
            var res = await usuarios.AddUsuarioAsync(x);
            if (res.Succeeded)
            {
                var resRol = await roles.AddRol(x, "Gestor");
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

        // PUT api/<GestorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] UsuarioDto x)
        {
            var usuario = await usuarios.GetUsuarioAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var res = await usuarios.PutUsuarioAsync(x,id);

            if (res.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE api/<GestorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
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
