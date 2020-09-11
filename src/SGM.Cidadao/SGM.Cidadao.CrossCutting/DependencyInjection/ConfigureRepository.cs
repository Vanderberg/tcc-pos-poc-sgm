using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGM.Cidadao.Data.Context;
using SGM.Cidadao.Data.Implementations;
using SGM.Cidadao.Data.Repository;
using SGM.Cidadao.Domain.Repository;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IPoliticaPublicaRepository, PoliticaPublicaImplementation>();
            
            serviceCollection.AddScoped<ConfigureSeed>();

            serviceCollection.AddDbContext<SgmContextCidadao>(
                
                options => options.UseMySql("server=localhost;userid=root;password=456852;database=SGM_CIDADAO")
                //options => options.UseMySql(configuration.GetConnectionString("InputsContext"))
            );
        }
    }
}