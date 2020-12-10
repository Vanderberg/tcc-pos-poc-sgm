using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGM.Cidadao.Domain.Interfaces.Services.Votacao;

namespace SGM.Cidadao.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotarController : ControllerBase
    {
        public IVotarService _service { get; set; }

        public VotarController(IVotarService service)
        {
            _service = service;
        }
        
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Votar(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Votar(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }  
    }
}