using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SGM.Cidadao.Domain.Entities.Enums;
using SGM.Gestao.Domain.Entities.Enums;
using SGM.Shared.Domain.Dtos;
using SGM.Shared.Domain.Entities;
using SGM.Shared.Domain.Results;
using SGM.Web.Application.Models;
using SGM.Web.Application.Models.ViewModels;
using SGM.Web.Application.Services;
using SGM.Shared.Domain.Entities.Enums;
using SGM.Web.Application.CustomAttributes;

namespace SGM.Web.Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericService<PoliticaPublica> _politicaPublicaService;
        private readonly IGenericService<Vaga> _VagaService;
        private string host;
        private int port;

        public HomeController(IConfiguration config, IGenericService<PoliticaPublica> politicaPublicaService, IGenericService<Vaga> vagaService)
        {
            _politicaPublicaService = politicaPublicaService;
            _VagaService = vagaService;
            _configuration = config;
            Prepare();
        }
        
        public override void SetToken(string token)
        {
            
        }

        protected override void Prepare()
        {
            this.host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            this.port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
            this._politicaPublicaService.SetUrl($"http://{host}:{port}/cidadao/PoliticaPublica");
            this._VagaService.SetUrl($"http://{host}:{port}/gestao/vaga");
        } 

        public IActionResult Privacy()
        {
            return View();
        }
        
        public async Task<IActionResult> Index()
        {
            Logoff();
            
            IEnumerable<PoliticaPublica> ListaPolitica = await _politicaPublicaService.FindAllAsync();
            IEnumerable<Vaga> ListaVagas = await _VagaService.FindAllAsync();
            var viewModel = new HomeViewModel
            {
                PoliticaPublica = ListaPolitica,
                Vagas = ListaVagas 
            };
            return View(viewModel);
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }
        
       
        
        public async Task<IActionResult> LoginUser(UserEntity user)
        {
            LoginDto loginDto = ConverteUserToLoginDto(user);
            var jsonContent = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            
            try
            {
                HttpClient client = new HttpClient();
                var result = client.PostAsync($"http://{this.host}:{this.port}/auth/Login", content).Result;

                string userToken = null;
                if (result.IsSuccessStatusCode)
                {
                    if (result.Content != null)
                    {
                        var responseContent = await result.Content.ReadAsStringAsync();
                        ResultToken resultToken = JsonConvert.DeserializeObject<ResultToken>(responseContent);
                        userToken = resultToken.accessToken;
                        HttpContext.Session.SetString("Role", resultToken.role.ToString());
                        HttpContext.Session.SetString("IsAuthenticated", true.ToString());
                    }
                }
                
                if (userToken != null)
                {
                   HttpContext.Session.SetString("JWToken", userToken);   //Save token in session object
                   
                   return Redirect("~/modulos/Index");
                }
                else
                {
                    return Redirect("~/home/Index");
                }   
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        
        private LoginDto ConverteUserToLoginDto(UserEntity user)
        {
            return new LoginDto(user.CPF, user.Password);
        }
        
        
        
    }
}