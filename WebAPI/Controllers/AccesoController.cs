using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Usuario;
using Shared.Dominio.Acceso;
using SkyBiometry.Client.FC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly BusinessLayer.IBL_Acceso acceso;

        public AccesoController(BusinessLayer.IBL_Acceso _acceso)
        {
            acceso = _acceso;
        }
        //GET: api/<AccesoController>/{id}
        [HttpGet("{id}")]
        public ActionResult Get([Required] Guid id)
        {
            var res = acceso.Get(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(acceso.Get(id));
        }

        //GET: api/<AccesoController>
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(acceso.GetAll());
        }

        //GET: api/<AccesoController>/Edificio/{idEdificio}
        [HttpGet("Edificio/{idEdificio}")]
        public ActionResult GetEdificios([Required] Guid idEdificio)
        {
            return Ok(acceso.GetAllEdificio(idEdificio));
        }

        //POST: api/<AccesoController>
        [HttpPost]
        public ActionResult Post([FromBody] AccesoCreateDto x)
        {
            return Ok(acceso.AddAcceso(x));
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody]AccesoCreateDto x, [Required] Guid id)
        {
            try
            {
                acceso.PutAcceso(x, id);
                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([Required] Guid id)
        {
            try
            {
                acceso.DeleteAcceso(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/<AccesoController>/Reconocer
        [HttpPost("Reconocer")]
        public async Task<ActionResult> ReconocerAsync([FromForm] AccesoReconocimientoDto accesoDto)
        {
            //if (accesoDto.Foto != null)
            //{
            //    var imagenes = new List<Stream>();
            //    var userIds = new List<string>();
            //    imagenes.Add(accesoDto.Foto.OpenReadStream());
            //    userIds.Add("all");
            //    var client = new FCClient("uhu60o2e1q4v5dogdue0s8nb1f", "tq7en8fnmibqgvshsgfv929i4h");
            //    var result = await client.Faces.RecognizeAsync(userIds, new List<string>(), imagenes, "lab");

            //    var personas = new List<UsuarioDto>();
            //    foreach (Photo fotoResult in result.Photos)
            //    {
            //        foreach (Tag tag in fotoResult.Tags)
            //        {
            //            var match = tag.Matches.FirstOrDefault(m => m.Confidence >= 75);
            //            if (match == null)
            //            {
            //                return NotFound();
            //            }
            //            var userId = match.UserId.Split('@').FirstOrDefault();
            //            if (userId != null)
            //            {
            //                var res = acceso.AddAcceso(new AccesoDto()
            //                {
            //                    EdificioId = accesoDto.EdificioId,
            //                    UsuarioId = userId
            //                });
            //                return Ok(res);
            //            }
            //        }
            //    }

            //    return NotFound();
            //}
            //else
            //{
            var acceso = await this.acceso.ReconocerAsync(accesoDto);
            if (acceso == null)
            {
                return NotFound();
            }
            return Ok(acceso);
            //}
        }

       
    }
}
