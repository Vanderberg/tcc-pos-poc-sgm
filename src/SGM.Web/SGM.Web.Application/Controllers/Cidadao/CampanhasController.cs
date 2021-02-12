using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SGM.Web.Application.Controllers.Filters;
using SGM.Web.Application.Models;
using SGM.Web.Application.Models.ViewModels;
using SGM.Web.Application.Services;

namespace SGM.Web.Application.Controllers
{
    [PegarTokenActionFilter]
    public class CampanhasController : BaseController
    {
       
        private readonly IConfiguration _configuration;
        private readonly IGenericService<Campanha> _campanhaService;

        public CampanhasController(IConfiguration config, IGenericService<Campanha> campanhaService )
        {
            this._configuration = config;
            this._campanhaService = campanhaService;
            Prepare();
        }

        public override void SetToken(string token)
        {
            this._campanhaService.SetToken(token);
        }
        
        protected override void Prepare()
        {
            string host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            int port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
            this._campanhaService.SetUrl($"http://{host}:{port}/cidadao/campanha");
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _campanhaService.FindAllAsync());
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não preenchido" });
            }

            var obj = await _campanhaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }
        
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }         
    }
}