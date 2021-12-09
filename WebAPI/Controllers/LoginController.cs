using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Dominio.Usuario;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Usuario _bl;
        private readonly IConfiguration _configuration;
        private readonly Boolean isLogged;
        public LoginController(BusinessLayer.IBL_Usuario bl, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _bl = bl;
            _configuration = configuration;
            isLogged = contextAccessor.HttpContext.User.Identity != null;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResult>> PostAsync(UsuarioLogin x)
        {
            if (isLogged)
            {
                var usuario = await _bl.Login(x);

                if (usuario != null)
                {
                    var roles = await _bl.GetRolesUsuarioAsync(usuario.Id);

                    var secretKey = _configuration.GetValue<string>("Secret");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id));
                    claims.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));
                    roles.ToList().ForEach(i => claims.AddClaim(new Claim(ClaimTypes.Role, i)));
                    var expira = DateTime.Now.AddHours(4);

                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = claims,
                        Expires = expira,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                    string bearerToken = tokenHandler.WriteToken(createdToken);


                    return Ok(new LoginResult()
                    {
                        Usuario = usuario,
                        Token = bearerToken,
                        Roles = roles,
                        Expira = expira
                    });
                }
                else
                {
                    return NotFound("Email o contraseña incorrectos");
                }
            }
            else
            {
                return BadRequest("Ya existe una sesión");
            }
            
        }
    }
}
