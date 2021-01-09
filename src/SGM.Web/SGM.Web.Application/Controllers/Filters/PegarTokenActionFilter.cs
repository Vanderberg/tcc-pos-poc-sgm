using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SGM.Web.Application.Controllers.Filters
{
    public class PegarTokenActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = (BaseController) context.Controller;
            controller.SetToken(controller.HttpContext.Session.GetString("JWToken"));
            //controller.ViewBag.UserRole = controller.HttpContext.Session.GetString("RoleAcces");
        }
    }
}