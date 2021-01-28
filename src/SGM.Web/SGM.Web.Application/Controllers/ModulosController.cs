using Microsoft.AspNetCore.Mvc;

namespace SGM.Web.Application.Controllers
{
    public class ModulosController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}