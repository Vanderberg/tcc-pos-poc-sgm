using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SGM.Cidadao.Domain.Dtos;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.Campanha;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Service.Services
{
    public class CampanhaService : ICampanhaService
    {
        private IRepository<CampanhaEntity> _repository;
        private readonly IMapper _mapper;

        public CampanhaService(IRepository<CampanhaEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<CampanhaEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id); 
        }

        public async Task<IEnumerable<CampanhaEntity>> GetAll()
        {
            return await _repository.SelectAsync(); 
        }

        public async Task<CampanhaEntity> Post(CampanhaDtoCreate campanha)
        {
            var entity = _mapper.Map<CampanhaEntity>(campanha);
            return await _repository.InsertAsync(entity);
        }

        public async Task<CampanhaEntity> Put(CampanhaDtoUpdate campanha)
        {
            var entity = _mapper.Map<CampanhaEntity>(campanha);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}