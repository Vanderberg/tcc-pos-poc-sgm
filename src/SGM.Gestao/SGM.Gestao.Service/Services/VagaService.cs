using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;
using SGM.Gestao.Domain.Interfaces.Services.Vaga;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Gestao.Service.Services
{
    public class VagaService :IVagaService
    {
        private IRepository<VagaEntity> _repository;
        private readonly IMapper _mapper;

        public VagaService(IRepository<VagaEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<VagaEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<VagaEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<VagaEntity> Post(VagaDtoCreate vaga)
        {
            var entity = _mapper.Map<VagaEntity>(vaga);
            return await _repository.InsertAsync(entity);
        }

        public async Task<VagaEntity> Put(VagaDtoUpdate vaga)
        {
            var entity = _mapper.Map<VagaEntity>(vaga);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}