using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGM.Cidadao.Domain.Dtos;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.Campanha;

namespace SGM.Cidadao.Application.Controllers
{
    [ApiController]
    [Route("cidadao/[controller]")]
    public class CampanhaController : ControllerBase
    {
        public ICampanhaService _service { get; set; }

        public CampanhaController(ICampanhaService service)
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
        [Route("{id}", Name = "GetCampanhaId")]
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
        public async Task<ActionResult> Post([FromBody] CampanhaDtoCreate campanha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(campanha);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetCampanhaId", new { id = result.Id })), result);
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
        public async Task<ActionResult> Put([FromBody] CampanhaDtoUpdate campanha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(campanha);
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