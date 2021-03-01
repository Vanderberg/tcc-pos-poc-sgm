using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGM.Shared.Domain.Entities;
using SGM.Shared.Domain.Entities.Enums;
using SGM.Web.Application.CustomAttributes;

namespace SGM.Web.Application.Controllers
{
    public class ModulosController : Controller
    {
        // GET
        public IActionResult Index()
        {
          /*  UserEntity objLoggedInUser = new UserEntity();
            var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = claimsIndentity.Claims;

            if (HttpContext.Session.GetString("IsAuthenticated").Equals(true.ToString()))
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

            ViewBag.UserRole = HttpContext.Session.GetString("Role");
            */
            
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
    }
}