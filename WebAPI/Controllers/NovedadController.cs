using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dominio.Novedades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Gestor")]
    public class NovedadController : ControllerBase
    {
        private readonly IBL_Novedad ibl_Novedad;
        public static IWebHostEnvironment environment;

        public NovedadController(IBL_Novedad _novedad, IWebHostEnvironment _environment )
        {
            ibl_Novedad = _novedad;
            environment = _environment;
        }

        

        // GET: api/<PuertaController>
        [HttpGet("Edificio/{IdEdificio}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<NovedadDto>> GetNovedadesEdificio(Guid IdEdificio)
        {
            return Ok(ibl_Novedad.GetNovedades(IdEdificio));
        }

        // GET: api/<PuertaController>
        [HttpGet("Ultimas")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<NovedadDto>> GetUltimas([FromHeader] Guid tenantId)
        {
            return Ok(ibl_Novedad.GetUltimas(tenantId));
        }

        // GET api/<NovedadController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<NovedadDto> Get(Guid id)
        {
            var novedad = ibl_Novedad.GetNovedad(id);

            if (novedad == null)
            {
                return NotFound();
            }
            return Ok(novedad);
        }

        // POST api/<NovedadController>
        [HttpPost]
        public ActionResult Post([FromForm] AgregarNovedadDto x)
        {
            try
            {
                if (x.ImagenFile.Length > 0)
                {
                    if (!Directory.Exists(environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(environment.WebRootPath + "\\Upload\\");
                    }
                    x.Imagen = "\\Upload\\" + Guid.NewGuid() + Path.GetExtension(x.ImagenFile.FileName);
                    using (FileStream fileStream = System.IO.File.Create(environment.WebRootPath + x.Imagen))
                    {
                        x.ImagenFile.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
            return Ok(ibl_Novedad.AddNovedad(x));
        }

        // DELETE api/<NovedadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var novedad = ibl_Novedad.GetNovedad(id);
            if (novedad == null)
            {
                return NotFound();
            }
            ibl_Novedad.DeleteNovedad(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromForm] AgregarNovedadDto x, Guid id)
        {
            try
            {
                if (x.ImagenFile.Length > 0)
                {
                    if (!Directory.Exists(environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(environment.WebRootPath + "\\Upload\\");
                    }
                    x.Imagen = "\\Upload\\" + Guid.NewGuid() + Path.GetExtension(x.ImagenFile.FileName);
                    using (FileStream fileStream = System.IO.File.Create(environment.WebRootPath + x.Imagen))
                    {
                        x.ImagenFile.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                ibl_Novedad.PutNovedad(x, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }

    }
}
