using Microsoft.AspNetCore.Authorization;
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
    public class UsuarioController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Usuario _bl;

        public UsuarioController(BusinessLayer.IBL_Usuario bl)
        {
            _bl = bl;
        }

        //GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Shared.Dominio.UsuarioDto> Get()
        {
            return _bl.GetUsuarios();
        }

        //POST: api/<UsuarioController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Shared.Dominio.UsuarioDto x)
        {
            var res = await _bl.AddUsuarioAsync(x);
            if (res.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
