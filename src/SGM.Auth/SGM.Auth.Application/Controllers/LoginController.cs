using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGM.Auth.Domain.Dtos;
using SGM.Auth.Domain.Interfaces.Services.User;
using System.Net;
using Microsoft.AspNetCore.Authorization;


namespace SGM.Auth.Application.Controllers
{
    [ApiController]
    [Route("autenticacao/[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (loginDto == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await service.FindByLogin(loginDto); //await service.FindByLogin(loginDto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}