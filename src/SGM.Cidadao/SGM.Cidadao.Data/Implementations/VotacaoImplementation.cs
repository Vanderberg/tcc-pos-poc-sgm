using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGM.Cidadao.Data.Context;
using SGM.Cidadao.Data.Repository;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Repository;

namespace SGM.Cidadao.Data.Implementations
{
    public class VotacaoImplementation : BaseRepository<VotacaoEntity>, IVotacaoRepository
    {
        private DbSet<VotacaoEntity> _dataset;
        
        public VotacaoImplementation(SgmContextCidadao context) : base(context)
        {
            _dataset = context.Set<VotacaoEntity>();
        }

        public Task<CampanhaEntity> FindBy(string descricao)
        {
            throw new System.NotImplementedException();
        }
    }
}