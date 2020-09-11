using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Domain.Repository
{
    public interface IPoliticaPublicaRepository : IRepository<PoliticaPublicaEntity>
    {
        Task<PoliticaPublicaEntity> FindByTitulo(string titulo);
    }
}