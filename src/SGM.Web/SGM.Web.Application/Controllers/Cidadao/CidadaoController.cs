using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SGM.Shared.Domain.Entities.Enums;
using SGM.Web.Application.Controllers.FilterCustom;
using SGM.Web.Application.Controllers.Filters;
using SGM.Web.Application.Models;

namespace SGM.Web.Application.Controllers
{
    [Authorize(TipoRetornoAcesso.WEB, Role.ADMIN, Role.MONITOR, Role.USER_COMMON, Role.MAINTENANCE)]
    [PegarTokenActionFilter]
    [RoleActionFilter]
    public class CidadaoController : BaseController
    {
        // GET
        public IActionResult Index()
        {
            List<Campanha> list = new List<Campanha>();
            list.Add(new Campanha{Id = new Guid(), Descricao = "Teste 1", DataFim = DateTime.Now, DataInicio = DateTime.Now});
            list.Add(new Campanha{Id = new Guid(), Descricao = "Teste 2", DataFim = DateTime.Now, DataInicio = DateTime.Now});
            
            return View(list);
        }

        public override void SetToken(string token)
        {
            //throw new NotImplementedException();
        }

        protected override void Prepare()
        {
            //throw new NotImplementedException();
        }
    }
}