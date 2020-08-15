using Microsoft.Extensions.DependencyInjection;
using SGM.Auth.Domain.Interfaces.Services.User;
using SGM.Auth.Service.Services;

namespace SGM.Auth.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}