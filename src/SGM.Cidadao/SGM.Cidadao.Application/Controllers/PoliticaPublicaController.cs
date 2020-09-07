using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGM.Cidadao.Domain.Interfaces.Services.PoliticaPublica;

namespace SGM.Cidadao.Application.Controllers
{
    [ApiController]
    [Route("cidadao/[controller]")]
    public class PoliticaPublicaController : ControllerBase
    {
        public IPoliticaPublicaService _service { get; set; }

        public PoliticaPublicaController(IPoliticaPublicaService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}