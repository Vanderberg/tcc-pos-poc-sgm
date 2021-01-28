namespace SGM.Web.Application.Controllers
{
    public abstract class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        public abstract void SetToken(string token);
        

        protected abstract void Prepare();
    }
}