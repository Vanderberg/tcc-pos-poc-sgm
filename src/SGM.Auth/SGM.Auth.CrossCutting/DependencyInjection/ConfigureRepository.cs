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

            string teste = configuration.GetConnectionString("InputsContext");
                
            serviceCollection.AddDbContext<SgmContext>(
                //options => options.UseMySql(configuration.GetConnectionString("server=127.0.0.1;userid=root;password=456852;database=SGM_AUTH"))
                
                options => options.UseMySql(teste)
            );
            
        }
    }
}