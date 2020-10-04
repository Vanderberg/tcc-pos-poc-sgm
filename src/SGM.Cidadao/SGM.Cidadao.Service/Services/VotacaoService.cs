using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SGM.Cidadao.Domain.Dtos;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.Votacao;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Service.Services
{
    public class VotacaoService : IVotacaoService
    {
        private IRepository<VotacaoEntity> _repository;
        private readonly IMapper _mapper;

        public VotacaoService(IRepository<VotacaoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<VotacaoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<VotacaoEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<VotacaoEntity> Post(VotacaoDtoCreate votacao)
        {
            var entity = _mapper.Map<VotacaoEntity>(votacao);
            return await _repository.InsertAsync(entity);
        }

        public async Task<VotacaoEntity> Put(VotacaoDtoUpdate votacao)
        {
            var entity = _mapper.Map<VotacaoEntity>(votacao);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
        
    }
}