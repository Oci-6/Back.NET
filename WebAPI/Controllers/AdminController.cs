using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Dominio.Usuario;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Roles roles;
        private readonly BusinessLayer.IBL_Usuario usuario;

        public AdminController(BusinessLayer.IBL_Roles roles, BusinessLayer.IBL_Usuario usuario)
        {
            this.roles = roles;
            this.usuario = usuario;
        }

        //POST: api/<AdminController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreateDto x)
        {
            var res = await usuario.AddUsuarioAsync(x);
            if (res.Succeeded)
            {
                var resRol = await roles.AddRol(x, "Admin");
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
        public async Task<IEnumerable<UsuarioDto>> GetAsync()
        {
            var users = await roles.GetUsuariosEnRol("Admin");
            return users;
        }

        //GET: api/<AdminController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetAsync(string id)
        {
            var res = await usuario.GetUsuarioAsync(id);
            if(res == null)
            {
                return NotFound();
            }

            return Ok(res);
        
        }

        //PUT: api/<AdminController>/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromBody] UsuarioDto x, string id)
        {
            if((await usuario.PutUsuarioAsync(x,id)).Succeeded)
            {
                return NoContent();
            }
            return NotFound();
        }
        //DELETE: api/<AdminController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync( string id)
        {
            if ((await usuario.DeleteUsuarioAsync(id)).Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
