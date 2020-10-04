using System;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Domain.Interfaces.Services.Votacao
{
    public interface IVotarService
    {
        Task<VotacaoEntity> Votar(Guid id);

    }
}