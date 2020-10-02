using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Domain.Interfaces.Services.Votacao
{
    public interface IVotacaoService
    {
        Task<VotacaoEntity> Get(Guid id);
        Task<IEnumerable<VotacaoEntity>> GetAll();
        Task<VotacaoEntity> Post(VotacaoEntity politica);
        Task<VotacaoEntity> Put(VotacaoEntity politica);
        Task<bool> Delete(Guid id);
    }
}