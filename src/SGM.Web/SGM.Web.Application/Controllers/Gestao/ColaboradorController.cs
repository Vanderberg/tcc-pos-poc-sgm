using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SGM.Web.Application.Controllers.Filters;
using SGM.Web.Application.Models;
using SGM.Web.Application.Models.ViewModels;
using SGM.Web.Application.Services;
using SGM.Web.Application.Services.Exceptions;

namespace SGM.Web.Application.Controllers.Gestao
{
    [PegarTokenActionFilter]
    public class ColaboradorController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericService<Colaborador> _colaboradorService;

        public ColaboradorController(IConfiguration config, IGenericService<Colaborador> colaboradorService )
        {
            this._configuration = config;
            this._colaboradorService = colaboradorService;
            Prepare();
        }
        public override void SetToken(string token)
        {
            this._colaboradorService.SetToken(token);
        }
        protected override void Prepare()
        {
            string host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            int port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
            this._colaboradorService.SetUrl($"http://{host}:{port}/gestao/Colaborador");
        }
        
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _colaboradorService.FindAllAsync());
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

            var obj = await _colaboradorService.FindByIdAsync(id.Value);
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