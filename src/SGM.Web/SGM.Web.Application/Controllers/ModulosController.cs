using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGM.Shared.Domain.Entities.Enums;
using SGM.Web.Application.CustomAttributes;

namespace SGM.Web.Application.Controllers
{
    public class ModulosController : BaseController
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult NoPermission()
        {
            ViewBag.UserRole = GetRole();
            return View("NoPermission");
        }
        
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public IActionResult Unauthorized()
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            ViewBag.UserRole = GetRole();
            return View("Unauthorized");
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

        public override void SetToken(string token)
        {
            //throw new System.NotImplementedException();
        }

        protected override void Prepare()
        {
            //throw new System.NotImplementedException();
        }
    }
}