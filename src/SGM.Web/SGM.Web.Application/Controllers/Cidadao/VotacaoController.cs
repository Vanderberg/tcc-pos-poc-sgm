using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SGM.Web.Application.Models;
using SGM.Web.Application.Models.ViewModels;
using SGM.Web.Application.Services;

namespace SGM.Web.Application.Controllers
{
    public class VotacaoController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericService<Votacao> _votacaoService;
        private readonly IGenericService<Votar> _votarService;
        private readonly IGenericService<PoliticaPublica> _politicaPublicaService;

        public VotacaoController(IConfiguration config, IGenericService<Votacao> votacaoService, IGenericService<PoliticaPublica> politicaPublicaService, IGenericService<Votar> VotarService)
        {
            this._configuration = config;
            this._votacaoService = votacaoService;
            this._votarService = VotarService;
            this._politicaPublicaService = politicaPublicaService;
            Prepare();            
        }

        public override void SetToken(string token)
        {
            this._votacaoService.SetToken(token);
        }

        protected override void Prepare()
        {
            string host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            int port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
            this._votarService.SetUrl($"http://{host}:{port}/cidadao/Votar");
            this._votacaoService.SetUrl($"http://{host}:{port}/cidadao/votacao");
            this._politicaPublicaService.SetUrl($"http://{host}:{port}/cidadao/politicapublica");
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _votacaoService.FindAllAsync());
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Votar(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não preenchido" });
            }

            var obj = await _votarService.VotarByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            var obj = await _politicaPublicaService.FindByIdAsync(id.Value);
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