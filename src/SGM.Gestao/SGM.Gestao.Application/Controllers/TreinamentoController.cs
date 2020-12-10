using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Interfaces.Services.Treinamento;

namespace SGM.Gestao.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]   
    public class TreinamentoController : ControllerBase
    {

        public ITreinamentoService _service;

        public TreinamentoController(ITreinamentoService service)
        {
            _service = service;
        }
        
        [Authorize("Bearer")]
        [HttpGet]
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
        
        [Authorize("Bearer")]       
        [HttpGet]
        [Route("{id}", Name = "GetTreinamentoId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }        
        
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TreinamentoDtoCreate treinamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(treinamento);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetTreinamentoId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }       
        
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TreinamentoDtoUpdate treinamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(treinamento);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }        
    }
}