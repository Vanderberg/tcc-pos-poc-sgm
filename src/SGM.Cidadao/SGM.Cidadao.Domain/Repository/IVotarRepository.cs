using System;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Domain.Repository
{
    public interface IVotarRepository : IRepository<VotacaoEntity>
    {
        Task<VotacaoEntity> Votar(Guid id); 
    }
}