using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SGM.Web.Application.Models;
using SGM.Web.Application.Services;

namespace SGM.Web.Application.Controllers
{
    public class VagaController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericService<Vaga> _vagaService;
        
        public VagaController(IConfiguration config, IGenericService<Vaga> vagaService )
        {
            this._configuration = config;
            this._vagaService = vagaService;
            Prepare();
        }

        public override void SetToken(string token)
        {
            this._vagaService.SetToken(token);
        }

        protected override void Prepare()
        {
            string host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            int port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
            this._vagaService.SetUrl($"http://{host}:{port}/gestao/vaga");
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _vagaService.FindAllAsync());
        }
        
    }
}