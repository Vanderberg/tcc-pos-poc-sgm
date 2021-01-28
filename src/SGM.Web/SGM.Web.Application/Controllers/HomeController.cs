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
        private readonly IGenericService<Vaga> _vagaService;
        private string host;
        private int port;

        public HomeController(IConfiguration config, IGenericService<PoliticaPublica> politicaPublicaService, IGenericService<Vaga> vagaService)
        {
            _politicaPublicaService = politicaPublicaService;
            _vagaService = vagaService;
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
            this._vagaService.SetUrl($"http://{host}:{port}/gestao/vaga");
        } 

        public IActionResult Privacy()
        {
            return View();
        }
        
        public async Task<IActionResult> Index()
        {
            Logoff();
            UserEntity objLoggedInUser = new UserEntity();
                var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = claimsIndentity.Claims;

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    foreach (var claim in userClaims)
                    {
                        var cType = claim.Type;
                        var cValue = claim.Value;
                        switch (cType)
                        {
                            case "USERID":
                                objLoggedInUser.Email = cValue;
                                break;
                            case "EMAILID":
                                objLoggedInUser.Email = cValue;
                                break;
                            case "ADMIN":
                                objLoggedInUser.AcessLevel = Role.ADMIN;
                                break;
                            case "MONITOR":
                                objLoggedInUser.AcessLevel = Role.MONITOR;
                                break;
                            case "USER_COMMON":
                                objLoggedInUser.AcessLevel = Role.USER_COMMON;
                                break;
                        }
                    }

                
            }
            ViewBag.UserRole = GetRole();
            IEnumerable<PoliticaPublica> ListaPolitica = await _politicaPublicaService.FindAllAsync();
            IEnumerable<Vaga> ListaVagas = await _vagaService.FindAllAsync();
            var viewModel = new HomeViewModel
            {
                PoliticaPublica = ListaPolitica,
                Vaga = ListaVagas
                
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
                    user.IsAuthenticated = true;
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
        
        private LoginDto ConverteUserToLoginDto(UserEntity user)
        {
            return new LoginDto(user.CPF, user.Password);
        }
        
        private string GetRole()
        {
            string valor = "";
            if (this.HavePermission(Role.ADMIN))
                valor = " - ADMIN";
            else
            if (this.HavePermission(Role.MONITOR))
                valor = " - MONITOR";
            else
            if (this.HavePermission(Role.MAINTENANCE))
                valor = " - MAINTENANCE";
            else
            if (this.HavePermission(Role.USER_COMMON))
                valor = " - USER_COMMON";
            else
                valor = "NOTHING";

            HttpContext.Session.SetString("RoleAcces", valor);
            return valor;
        }
        
    }
}