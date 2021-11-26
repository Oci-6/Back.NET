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

        //GET: api/<AccesoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]AccesoCreateDto accesoDto)
        {
            if (accesoDto.Foto != null)
            {
                var imagenes = new List<Stream>();
                var userIds = new List<string>();
                imagenes.Add(accesoDto.Foto.OpenReadStream());
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
                            var res = acceso.AddAcceso(new AccesoDto()
                            {
                                EdificioId = accesoDto.EdificioId,
                                UsuarioId = userId
                            });
                            return Ok(res);
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

        //GET: api/<AccesoController>
        [HttpGet("{idEdificio}")]
        public ActionResult Get([Required] Guid idEdificio)
        {
            return Ok(acceso.GetAccesos(idEdificio));
        }
    }
}
