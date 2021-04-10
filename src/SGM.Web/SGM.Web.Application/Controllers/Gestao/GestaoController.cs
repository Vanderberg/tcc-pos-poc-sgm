using Microsoft.AspNetCore.Mvc;
using SGM.Shared.Domain.Entities.Enums;
using SGM.Web.Application.Controllers.FilterCustom; //custom
using SGM.Web.Application.Controllers.Filters;

namespace SGM.Web.Application.Controllers.Gestao
{
    [Authorize(TipoRetornoAcesso.WEB, Role.ADMIN, Role.MONITOR, Role.USER_COMMON, Role.MAINTENANCE)]
    [PegarTokenActionFilter]
    [RoleActionFilter]
    public class GestaoController : BaseController
    {
        public override void SetToken(string token)
        {
           // throw new System.NotImplementedException();
        }

        protected override void Prepare()
        {
            //throw new System.NotImplementedException();
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
    }
}