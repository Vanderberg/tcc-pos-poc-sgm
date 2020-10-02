using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Domain.Repository
{
    public interface IVotacaoRepository : IRepository<VotacaoEntity>
    {
        Task<CampanhaEntity> FindBy(string descricao); 
    }
}