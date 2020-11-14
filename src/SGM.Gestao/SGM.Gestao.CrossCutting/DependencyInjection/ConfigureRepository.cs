using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGM.Gestao.Data.Context;
using SGM.Gestao.Data.Repository;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Gestao.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
/*            serviceCollection.AddScoped<IPoliticaPublicaRepository, PoliticaPublicaImplementation>();
            serviceCollection.AddScoped<ICampanhaRepository, CampanhaImplementation>();
            serviceCollection.AddScoped<IVotacaoRepository, VotacaoImplementation>();
            serviceCollection.AddScoped<IVotarRepository, VotarImplementation>();
   */         
            serviceCollection.AddScoped<ConfigureSeed>();

            serviceCollection.AddDbContext<SgmContextGestao>(
                
                options => options.UseMySql("server=localhost;userid=root;password=456852;database=SGM_GESTAO")
                //options => options.UseMySql(configuration.GetConnectionString("InputsContext"))
            );
        }        
    }
}