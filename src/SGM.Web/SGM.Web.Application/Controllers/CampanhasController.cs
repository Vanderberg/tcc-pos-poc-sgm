using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SGM.Web.Application.Controllers.Filters;
using SGM.Web.Application.Models;
using SGM.Web.Application.Services;

namespace SGM.Web.Application.Controllers
{
    [PegarTokenActionFilter]
    public class CampanhasController : BaseController
    {
       
        private readonly IConfiguration _configuration;
        private readonly IGenericService<Campanha> _campanhaService;
        protected readonly HttpClient _clientHttp;


        public CampanhasController(IConfiguration config, IGenericService<Campanha> campanhaService )
        {
            this._configuration = config;
            this._campanhaService = campanhaService;
            Prepare();
        }

        protected override void Prepare()
        {
            string host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            int port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
            this._campanhaService.SetUrl($"http://{host}:{port}/cidadao/campanha");
        }
        
        public override void SetToken(string token)
        {
            this._campanhaService.SetToken(token);
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _campanhaService.FindAllAsync());
        }

        public IActionResult Edit()
        {
            return View();
        }
        
        public IActionResult Detalhe()
        {
            return View();
        }
        
        public IActionResult Delete()
        {
            return View();
        }        
    }
}