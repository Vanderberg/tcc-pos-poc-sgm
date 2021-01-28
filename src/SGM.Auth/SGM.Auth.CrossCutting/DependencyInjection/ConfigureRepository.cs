using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGM.Auth.Data.Implementations;
using SGM.Auth.Domain.Repository;
using SGM.Auth.Data.Repository;
using SGM.Shared.Domain.Interfaces;
using SGM.Auth.Data.Context;

namespace SGM.Auth.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<ConfigureSeed>();
                
            serviceCollection.AddDbContext<SgmContext>(
                options => options.UseMySql(configuration.GetConnectionString("InputsContext"))
            );
            
        }
    }
}