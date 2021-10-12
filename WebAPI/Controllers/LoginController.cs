using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Dominio;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BusinessLayer.IBL.IBL_Usuario _bl;
        private readonly IConfiguration _configuration;
        public LoginController(BusinessLayer.IBL.IBL_Usuario bl, IConfiguration configuration)
        {
            _bl = bl;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult<Usuario> Post(UsuarioLogin x)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Usuario usuario = _bl.GetUsuarios().Where(element => x.nombre == element.nombre).FirstOrDefault();

            if(usuario == null)
            {
                return NotFound();
            }
            else
            {
                var secretKey = _configuration.GetValue<string>("Secret");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.nombre));

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                string bearerToken = tokenHandler.WriteToken(createdToken);


                    return Ok(bearerToken);
            }
        }
    }
}
