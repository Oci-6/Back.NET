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
using Shared.Dominio.Usuario;
using OfficeOpenXml;
using System.ComponentModel.DataAnnotations;
using Shared.Dominio.Persona;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Roles roles;
        private readonly BusinessLayer.IBL_Persona usuario;

        public PersonaController(BusinessLayer.IBL_Roles roles, BusinessLayer.IBL_Persona usuario)
        {
            this.roles = roles;
            this.usuario = usuario;
        }

        //POST: api/<PersonaController>
        [HttpPost]
        public async Task<ActionResult> Crear([FromForm] Shared.Dominio.Persona.PersonaCreateDto x)
        {

            try
            {
                return Ok(await usuario.AddPersonaAsync(x));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //POST: api/<PersonaController>/Importar
        [HttpPost("Importar")]
        public async Task<ActionResult> Import([Required] IFormFile excel)
        {
            var list = new List<PersonaCreateDto>();
            using (var stream = new MemoryStream())
            {
                await excel.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        var usuarioDto = new PersonaCreateDto();
                        usuarioDto.Email = worksheet.Cells[row, 1].Value.ToString();
                        usuarioDto.Nombre = worksheet.Cells[row, 2].Value.ToString();
                        usuarioDto.Apellido = worksheet.Cells[row, 3].Value.ToString();
                        usuarioDto.TipoDocumento = worksheet.Cells[row, 4].Value.ToString();
                        usuarioDto.Documento = worksheet.Cells[row, 5].Value.ToString();
                        usuarioDto.Telefono = worksheet.Cells[row, 6].Value.ToString();
                        await usuario.AddPersonaAsync(usuarioDto);
                        list.Add(usuarioDto);
                    }
                }
            }

            return Ok(list);
        }

        //GET: api/<PersonaController>
        [HttpGet]
        public  IEnumerable<PersonaDto> Get()
        {
            return usuario.GetPersonas();
        }

        ////POST: api/<PersonaController>/Reconocer
        //[HttpPost("Reconocer")]
        //public async Task<ActionResult> GetReconocimiento([Required] IFormFile foto)
        //{
        //    if (foto != null)
        //    {
        //        var imagenes = new List<Stream>();
        //        var userIds = new List<string>();
        //        imagenes.Add(foto.OpenReadStream());
        //        userIds.Add("all");
        //        var client = new FCClient("uhu60o2e1q4v5dogdue0s8nb1f", "tq7en8fnmibqgvshsgfv929i4h");
        //        var result = await client.Faces.RecognizeAsync(userIds, new List<string>(), imagenes, "lab");

        //        var personas = new List<UsuarioDto>();
        //        foreach (Photo fotoResult in result.Photos)
        //        {
        //            foreach (Tag tag in fotoResult.Tags)
        //            {
        //                var match = tag.Matches.FirstOrDefault(m => m.Confidence >= 75);
        //                if (match == null)
        //                {
        //                    return NotFound();
        //                }
        //                var userId = match.UserId[..match.UserId.LastIndexOf('@')];

        //                if (userId != null)
        //                {
        //                    var user = await usuario.GetUsuarioAsync(userId);
        //                    if (user == null)
        //                    {
        //                        return NotFound();
        //                    }
        //                    return Ok(user);
        //                }
        //            }
        //        }

        //        return NotFound();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //GET: api/<PersonaController>/{id}
        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> Get(Guid id)
        {
            var res = usuario.GetPersona(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        //GET: api/<PersonaController>/Buscar
        [HttpGet("Buscar")]
        public async Task<ActionResult<UsuarioDto>> BuscarPersonas([FromQuery] string query,int page = 1)
        {
            var res = await usuario.GetPersonasAsync(query, page, 10);

            return Ok(res);

        }

        //PUT: api/<PersonaController>/{id}
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] PersonaCreateDto x, Guid id)
        {
            try
            {
                usuario.PutPersona(x, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //DELETE: api/<PersonaController>/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                usuario.DeletePersona(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
