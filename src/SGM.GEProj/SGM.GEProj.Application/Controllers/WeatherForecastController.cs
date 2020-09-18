using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SGM.GEProj.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return  StatusCode(200, "Teste OK - WeatherForecastController");
        }
    }
}
