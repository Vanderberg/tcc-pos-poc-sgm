using System;
using System.Threading.Tasks;
using AutoMapper;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.Votacao;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Service.Services
{
    public class VotarService : IVotarService
    {
        private IRepository<VotacaoEntity> _repository;
        private readonly IMapper _mapper;

        public VotarService(IRepository<VotacaoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
            
        public async Task<VotacaoEntity> Votar(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            entity.Votos++;
            return await _repository.UpdateAsync(entity);
        }
    }
}