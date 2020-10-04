using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGM.Cidadao.Data.Context;
using SGM.Cidadao.Data.Repository;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Repository;

namespace SGM.Cidadao.Data.Implementations
{
    public class VotarImplementation : BaseRepository<VotacaoEntity>, IVotarRepository
    {
        private DbSet<VotacaoEntity> _dataset;
        
        public VotarImplementation(SgmContextCidadao context) : base(context)
        {
            _dataset = context.Set<VotacaoEntity>();
        }

        public Task<VotacaoEntity> Votar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}