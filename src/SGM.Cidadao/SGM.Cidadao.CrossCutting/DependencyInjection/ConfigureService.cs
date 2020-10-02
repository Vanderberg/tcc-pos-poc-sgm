using Microsoft.Extensions.DependencyInjection;
using SGM.Cidadao.Domain.Interfaces.Services.Campanha;
using SGM.Cidadao.Domain.Interfaces.Services.PoliticaPublica;
using SGM.Cidadao.Domain.Interfaces.Services.Votacao;
using SGM.Cidadao.Service.Services;

namespace SGM.Cidadao.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPoliticaPublicaService, PoliticaPublicaService>();
            serviceCollection.AddTransient<ICampanhaService, CampanhaService>();
            serviceCollection.AddTransient<IVotacaoService, VotacaoService>();
        }
    }
}