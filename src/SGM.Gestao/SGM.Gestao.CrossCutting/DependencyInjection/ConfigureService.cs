using Microsoft.Extensions.DependencyInjection;
using SGM.Gestao.Domain.Interfaces.Services.Colaborador;
using SGM.Gestao.Domain.Interfaces.Services.Treinamento;
using SGM.Gestao.Domain.Interfaces.Services.Vaga;
using SGM.Gestao.Service.Services;

namespace SGM.Gestao.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IVagaService, VagaService>();
            serviceCollection.AddTransient<ITreinamentoService, TreinamentoService>();
            serviceCollection.AddTransient<IColaboradorService, ColaboradorService>();
        }
    }
}