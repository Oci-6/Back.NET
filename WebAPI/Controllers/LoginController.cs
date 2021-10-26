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
        private readonly BusinessLayer.IBL_Usuario _bl;
        private readonly IConfiguration _configuration;
        public LoginController(BusinessLayer.IBL_Usuario bl, IConfiguration configuration)
        {
            _bl = bl;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResult>> PostAsync(UsuarioLogin x)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UsuarioDto usuario = _bl.GetUsuarios().Where(element => x.Email == element.Email).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                var roles = await _bl.GetRolesUsuarioAsync(usuario.Id);

                var secretKey = _configuration.GetValue<string>("Secret");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Email));
                roles.ToList().ForEach(i => claims.AddClaim(new Claim(ClaimTypes.Role, i)));

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                string bearerToken = tokenHandler.WriteToken(createdToken);


                return Ok(new LoginResult()
                {
                    Usuario = usuario,
                    Token = bearerToken,
                    Roles = roles
                });
            }
        }
    }
}
