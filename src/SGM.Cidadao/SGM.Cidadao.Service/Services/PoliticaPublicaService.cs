
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.PoliticaPublica;
using SGM.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.Cidadao.Service.Services
{
    public class PoliticaPublicaService : IPoliticaPublicaService
    {
        private IRepository<PoliticaPublicaEntity> _repository;

        public PoliticaPublicaService(IRepository<PoliticaPublicaEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PoliticaPublicaEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
            //var entity = await _repository.SelectAsync(id);
            //return _mapper.Map<PoliticaPublicaEntity>(entity) ?? new PoliticaPublicaEntity();
        }

        public async Task<IEnumerable<PoliticaPublicaEntity>> GetAll()
        {
            return await _repository.SelectAsync(); 
            //var listentity = await _repository.SelectAsync();
            //return _mapper.Map<IEnumerable<PoliticaPublicaEntity>>(listentity);
        }

        public async Task<PoliticaPublicaEntity> Post(PoliticaPublicaEntity politica)
        {
            return await _repository.InsertAsync(politica);
            //var entity = _mapper.Map<PoliticaPublicaEntity>(politica);
            //var result = await _repository.InsertAsync(entity);
            //return _mapper.Map<PoliticaPublicaEntity>(result);
        }

        public async Task<PoliticaPublicaEntity> Put(PoliticaPublicaEntity politica)
        {
            return await _repository.UpdateAsync(politica);
            //var entity = _mapper.Map<PoliticaPublicaEntity>(politica);
            //var result = await _repository.UpdateAsync(entity);
            //return _mapper.Map<PoliticaPublicaEntity>(result);
        }
    }
}
