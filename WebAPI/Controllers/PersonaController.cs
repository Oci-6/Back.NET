using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SkyBiometry.Client.FC;
using Shared.Dominio;
using OfficeOpenXml;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult> Post([FromHeader] Guid TenantId, [FromForm] Shared.Dominio.Persona.PersonaCreateDto x)
        {
            x.Id = Guid.NewGuid().ToString();
            x.Password = Guid.NewGuid().ToString();
            var res = await usuario.AddUsuarioAsync(x);
            if (res.Succeeded)
            {
                var resRol = await roles.AddRol(x, "Persona");
                if (resRol.Succeeded)
                {
                    if (x.Foto != null)
                    {

                        var imagenes = new List<Stream>();
                        var userIds = new List<string>();
                        var urls = new List<string>();
                        imagenes.Add(x.Foto.OpenReadStream());
                        userIds.Add("all");

                        var client = new FCClient("uhu60o2e1q4v5dogdue0s8nb1f", "tq7en8fnmibqgvshsgfv929i4h");
                        var result = await client.Faces.RecognizeAsync(userIds, new List<string>(), imagenes, "lab");
                        foreach (Photo foto in result.Photos)
                        {
                            await client.Tags.SaveAsync(foto.Tags.Select(x => x.TagId).ToArray(), x.Id + "@lab");

                        }
                        //var tags = new List<string>();
                        //tags.Add("TEMP_F@0904f19a2e0791f56410a30300db0087_2e4caab58e7bd_43.80_40.54_0_1");
                        //var result = await client.Tags.SaveAsync(tags, "chayanne@lab");
                        userIds = new List<string>();
                        userIds.Add(x.Id + "@lab");
                        result = await client.Faces.TrainAsync(userIds);

                        return Ok(result);
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
            else
            {
                return BadRequest();
            }


        }

        //POST: api/<PersonaController>
        [HttpPost("Importar")]
        public async Task<ActionResult> Import([FromHeader] Guid TenantId, [Required] IFormFile excel)
        {
            var list = new List<UsuarioDto>();
            using (var stream = new MemoryStream())
            {
                await excel.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        var usuarioDto = new UsuarioDto();
                        usuarioDto.Id = Guid.NewGuid().ToString();
                        usuarioDto.Email = worksheet.Cells[row, 1].Value.ToString();
                        usuarioDto.Password = Guid.NewGuid().ToString();
                        usuarioDto.Nombre = worksheet.Cells[row, 2].Value.ToString();
                        usuarioDto.Apellido = worksheet.Cells[row, 3].Value.ToString();
                        usuarioDto.TipoDocumento = worksheet.Cells[row, 4].Value.ToString();
                        usuarioDto.Documento = worksheet.Cells[row, 5].Value.ToString();
                        usuarioDto.PhoneNumber = worksheet.Cells[row, 6].Value.ToString();
                        usuarioDto.TenantInstitucionId = TenantId;
                        await usuario.AddUsuarioAsync(usuarioDto);
                        await roles.AddRol(usuarioDto, "Persona");
                        list.Add(usuarioDto);
                    }
                }
            }

            return Ok(list);
        }

        //GET: api/<PersonaController>
        [HttpGet]
        public async Task<IEnumerable<Shared.Dominio.UsuarioDto>> GetAsync([FromHeader] Guid TenantId)
        {
            var users = await roles.GetUsuariosEnRol("Persona");
            return users;
        }

        //GET: api/<PersonaController>/Reconocer
        [HttpPost("Reconocer")]
        public async Task<ActionResult> GetReconocimiento([FromHeader] Guid TenantId, [Required] IFormFile foto)
        {
            if (foto != null)
            {
                var imagenes = new List<Stream>();
                var userIds = new List<string>();
                imagenes.Add(foto.OpenReadStream());
                userIds.Add("all");
                var client = new FCClient("uhu60o2e1q4v5dogdue0s8nb1f", "tq7en8fnmibqgvshsgfv929i4h");
                var result = await client.Faces.RecognizeAsync(userIds, new List<string>(), imagenes, "lab");

                var personas = new List<UsuarioDto>();
                foreach (Photo fotoResult in result.Photos)
                {
                    foreach (Tag tag in fotoResult.Tags)
                    {
                        var match = tag.Matches.FirstOrDefault(m => m.Confidence >= 75);
                        if (match == null)
                        {
                            return NotFound();
                        }
                        var userId = match.UserId.Split('@').FirstOrDefault();
                        if (userId != null)
                        {
                            var user = await usuario.GetUsuarioAsync(userId);
                            if (user == null)
                            {
                                return NotFound();
                            }
                            return Ok(user);
                        }
                    }
                }

                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        //GET: api/<PersonaController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Shared.Dominio.UsuarioDto>> GetAsync([FromHeader] Guid TenantId, string id)
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
        public async Task<ActionResult> PutAsync([FromHeader] Guid TenantId, [FromBody] Shared.Dominio.UsuarioDto x, string id)
        {
            if ((await usuario.PutUsuarioAsync(x, id)).Succeeded)
            {
                return NoContent();
            }
            return NotFound();
        }
        //DELETE: api/<PersonaController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromHeader] Guid TenantId, string id)
        {
            if ((await usuario.DeleteUsuarioAsync(id)).Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
