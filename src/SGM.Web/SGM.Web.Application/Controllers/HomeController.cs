using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SGM.Shared.Domain.Dtos;
using SGM.Shared.Domain.Entities;
using SGM.Shared.Domain.Results;
using SGM.Web.Application.Models;
using SGM.Web.Application.Models.ViewModels;
using SGM.Web.Application.Services;

namespace SGM.Web.Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IConfiguration _configuration;
        private string _host;
        private int _port;

        public HomeController(IConfiguration config, IGenericService<Campanha> campanhaService )
        {
            _configuration = config;
            Prepare();
        }
        
        public override void SetToken(string token)
        {
            
        }

        protected override void Prepare()
        {
            this._host = this._configuration.GetSection("ConfigApp").GetSection("host").Value;
            this._port = ConfigurationBinder.GetValue<int>(this._configuration.GetSection("ConfigApp"), "port", 80);
        } 

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        public async Task<IActionResult> LoginUser(UserEntity user)
        {
            LoginDto loginDto = ConverteUserToLoginDto(user);
            var jsonContent = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var result = client.PostAsync($"http://{this._host}:{this._port}/auth/Login", content).Result;

            string userToken = null;
            if (result.IsSuccessStatusCode)
            {
                if (result.Content != null)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    ResultToken resultToken = JsonConvert.DeserializeObject<ResultToken>(responseContent);
                    userToken = resultToken.accessToken;
                }
            }

            if (userToken != null)
            {
               HttpContext.Session.SetString("JWToken", userToken);   //Save token in session object
               
            }
            return Redirect("~/Home/Index");
        }
        
        private LoginDto ConverteUserToLoginDto(UserEntity user)
        {
            return new LoginDto(user.Email, user.FirstName);
        }
    }
}