using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Domain.Repository
{
    public interface ICampanhaRepository : IRepository<CampanhaEntity>
    {
        Task<CampanhaEntity> FindByDescricao(string descricao); 
    }
}