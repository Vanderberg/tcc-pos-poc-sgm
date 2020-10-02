using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.Votacao;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Service.Services
{
    public class VotacaoService : IVotacaoService
    {
        private IRepository<VotacaoEntity> _repository;

        public VotacaoService(IRepository<VotacaoEntity> repository)
        {
            _repository = repository;
        }
        
        public async Task<VotacaoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<VotacaoEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<VotacaoEntity> Post(VotacaoEntity votacao)
        {
            return await _repository.InsertAsync(votacao);
        }

        public async Task<VotacaoEntity> Put(VotacaoEntity votacao)
        {
            return await _repository.UpdateAsync(votacao);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}