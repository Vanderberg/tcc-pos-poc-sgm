using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.Campanha;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Cidadao.Service.Services
{
    public class CampanhaService : ICampanhaService
    {
        private IRepository<CampanhaEntity> _repository;

        public CampanhaService(IRepository<CampanhaEntity> repository)
        {
            _repository = repository;
        }
        
        public async Task<CampanhaEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id); 
        }

        public async Task<IEnumerable<CampanhaEntity>> GetAll()
        {
            return await _repository.SelectAsync(); 
        }

        public async Task<CampanhaEntity> Post(CampanhaEntity campanha)
        {
            return await _repository.InsertAsync(campanha);
        }

        public async Task<CampanhaEntity> Put(CampanhaEntity campanha)
        {
            return await _repository.UpdateAsync(campanha);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}