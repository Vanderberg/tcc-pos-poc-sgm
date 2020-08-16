using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SGM.Auth.Data.Context;
using SGM.Auth.Data.Implementations;
using SGM.Auth.Data.Repository;
using SGM.Auth.Domain.Interfaces;
using SGM.Auth.Domain.Repository;

namespace SGM.Auth.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<ConfigureSeed>();

            serviceCollection.AddDbContext<AuthContext>(
                options => options.UseMySql("server=127.0.0.1;userid=root;password=456852;database=SGM_AUTH")
            );
        }
    }
}