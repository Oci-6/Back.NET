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
        private readonly BusinessLayer.IBL.IBL_Usuario _bl;

        public UsuarioController(BusinessLayer.IBL.IBL_Usuario bl)
        {
            _bl = bl;
        }

        //GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Shared.Dominio.Usuario> Get()
        {
            return _bl.GetUsuarios();
        }

        //GET: api/<UsuarioController>
        [AllowAnonymous]
        [HttpPost]
        public Shared.Dominio.Usuario Post([FromBody] Shared.Dominio.Usuario x)
        {
            return _bl.AddUsuario(x);
        }
    }
}
