using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGM.Cidadao.Data.Context;
using SGM.Cidadao.Data.Repository;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Repository;

namespace SGM.Cidadao.Data.Implementations
{
    public class CampanhaImplementation : BaseRepository<CampanhaEntity>, ICampanhaRepository
    {
        private DbSet<CampanhaEntity> _dataset;
        
        public CampanhaImplementation(SgmContextCidadao context) : base(context)
        {
            _dataset = context.Set<CampanhaEntity>();
        }

        public async Task<CampanhaEntity> FindByDescricao(string descricao)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Descricao.Equals(descricao));
        }
    }
}