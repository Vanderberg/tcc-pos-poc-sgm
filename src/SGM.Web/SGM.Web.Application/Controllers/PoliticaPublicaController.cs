using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SGM.Cidadao.Domain.Entities;
using SGM.Web.Application.Models;
using SGM.Web.Application.Services;

namespace SGM.Web.Application.Controllers
{
    public class PoliticaPublicaController : BaseController
    {
        
        private readonly IConfiguration _configuration;
        private readonly IGenericService<PoliticaPublica> _politicaPublicaService;

        public PoliticaPublicaController(IConfiguration config, IGenericService<PoliticaPublica> politicaPublicaService )
        {
            this._configuration = config;
            this._politicaPublicaService = politicaPublicaService;
            Prepare();            
        }

        public override void SetToken(string token)
        {
            this._politicaPublicaService.SetToken(token);
        }

        protected override void Prepare()
        {
            string host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            int port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
            this._politicaPublicaService.SetUrl($"http://{host}:{port}/cidadao/politicaPublica");
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _politicaPublicaService.FindAllAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            var obj = await _politicaPublicaService.FindByIdAsync(id.Value);
            return View(obj);
        }
    }
}