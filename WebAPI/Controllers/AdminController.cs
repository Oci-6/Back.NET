using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Admin bl;
        private readonly BusinessLayer.IBL_Usuario bl_usuario;

        public AdminController(BusinessLayer.IBL_Admin _bl, BusinessLayer.IBL_Usuario _bl_usuario)
        {
            bl = _bl;
            bl_usuario = _bl_usuario;
        }

        //POST: api/<AdminController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Shared.Dominio.UsuarioDto x)
        {
            x.Id = Guid.NewGuid().ToString();
            var res = await bl_usuario.AddUsuarioAsync(x);
            if (res.Succeeded)
            {
                var resRol = await bl.AddAdminAsync(x);
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
        public async Task<IEnumerable<Shared.Dominio.UsuarioDto>> GetAsync()
        {
            return await bl.GetAdminsAsync();
        }

        //GET: api/<AdminController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Shared.Dominio.UsuarioDto>> GetAsync(string id)
        {
            var res = await bl_usuario.GetUsuarioAsync(id);
            if(res == null)
            {
                return NotFound();
            }

            return Ok(res);
        
        }

        //PUT: api/<AdminController>/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromBody] Shared.Dominio.UsuarioDto x, string id)
        {
            if((await bl_usuario.PutUsuarioAsync(x,id)).Succeeded)
            {
                return NoContent();
            }
            return NotFound();
        }
        //DELETE: api/<AdminController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync( string id)
        {
            if ((await bl_usuario.DeleteUsuarioAsync(id)).Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
