using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SGM.Cidadao.Application.Controllers
{
    [ApiController]
    [Route("cidadao/[controller]")]
    public class PoliticaController : ControllerBase
    {
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return  StatusCode(200, "Teste OK - PoliticaController");
        }   
    }
}