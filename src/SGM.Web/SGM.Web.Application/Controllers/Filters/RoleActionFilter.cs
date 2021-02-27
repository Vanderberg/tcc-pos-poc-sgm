using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SGM.Web.Application.Controllers.Filters
{
    public class RoleActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = (BaseController)context.Controller;
            controller.ViewBag.UserRole = controller.HttpContext.Session.GetString("RoleAcces");
        }
    }
}