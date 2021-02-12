using Microsoft.AspNetCore.Mvc;
using SGM.Web.Application.Controllers.Filters;

namespace SGM.Web.Application.Controllers.Gestao
{
    public class GestaoController : BaseController
    {
        public override void SetToken(string token)
        {
            throw new System.NotImplementedException();
        }

        protected override void Prepare()
        {
            throw new System.NotImplementedException();
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
    }
}