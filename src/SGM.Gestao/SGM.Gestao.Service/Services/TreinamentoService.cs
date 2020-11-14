using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;
using SGM.Gestao.Domain.Interfaces.Services.Treinamento;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Gestao.Service.Services
{
    public class TreinamentoService : ITreinamentoService
    {
        private IRepository<TreinamentoEntity> _repository;
        private readonly IMapper _mapper;

        public TreinamentoService(IRepository<TreinamentoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TreinamentoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<TreinamentoEntity>> GetAll()
        {
            return await _repository.SelectAsync(); 
        }

        public async Task<TreinamentoEntity> Post(TreinamentoDtoCreate treinamento)
        {
            var entity = _mapper.Map<TreinamentoEntity>(treinamento);
            return await _repository.InsertAsync(entity);
        }

        public async Task<TreinamentoEntity> Put(TreinamentoDtoUpdate treinamento)
        {
            var entity = _mapper.Map<TreinamentoEntity>(treinamento);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}