using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Dtos;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Domain.Interfaces.Services.Votacao
{
    public interface IVotacaoService
    {
        Task<VotacaoEntity> Get(Guid id);
        Task<IEnumerable<VotacaoEntity>> GetAll();
        Task<VotacaoEntity> Post(VotacaoDtoCreate politica);
        Task<VotacaoEntity> Put(VotacaoDtoUpdate politica);
        Task<bool> Delete(Guid id);
    }
}