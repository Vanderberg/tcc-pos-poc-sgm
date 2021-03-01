using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SGM.Shared.Domain.Entities.Enums;
using SGM.Shared.Domain.Results;

namespace SGM.Web.Application.Controllers.FilterCustom
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        
        public AuthorizeAttribute(TipoRetornoAcesso tipoRetorno, params Role[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { tipoRetorno, claim };
        }
        
        public class AuthorizeFilter : IAuthorizationFilter
        {
            private readonly Role[] _claim;
            private readonly TipoRetornoAcesso _tipoRetorno;

            public AuthorizeFilter(TipoRetornoAcesso tipoRetorno, params Role[] claim)
            {
                this._tipoRetorno = tipoRetorno;
                this._claim = claim;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                string IsAuthenticated = context.HttpContext.Session.GetString("IsAuthenticated");
                string Role = context.HttpContext.Session.GetString("Role");
            
                if (IsAuthenticated == null)
                {
                    if (this._tipoRetorno.Equals(TipoRetornoAcesso.WEB))
                    {
                        context.Result = new RedirectResult("~/Modulos/NoPermission");
                    } else
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.Result = new JsonResult(new ResultApi(false, "Forbidden Access"));
                    }
                 
                } else if (IsAuthenticated.Equals(true.ToString()))
                {
                    bool flagClaim = false;
                    foreach (var item in _claim)
                    {
                        if (Role.Equals(item.ToString()))
                            flagClaim = true;
                    }
                    if (!flagClaim)
                    {
                        if (this._tipoRetorno.Equals(TipoRetornoAcesso.WEB))
                        {
                            context.Result = new RedirectResult("~/Modulos/Unauthorized");
                        } else
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new ResultApi(false, "Unauthorized"));
                        }
                    }
                } 
                return;
            }
        }
    }
}