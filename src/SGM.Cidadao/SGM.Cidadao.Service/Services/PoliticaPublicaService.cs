
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.PoliticaPublica;
using SGM.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SGM.Cidadao.Domain.Dtos;

namespace SGM.Cidadao.Service.Services
{
    public class PoliticaPublicaService : IPoliticaPublicaService
    {
        private IRepository<PoliticaPublicaEntity> _repository;
        private readonly IMapper _mapper;
        public PoliticaPublicaService(IRepository<PoliticaPublicaEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public async Task<PoliticaPublicaEntity> Post(PoliticaPublicaDtoCreate politica)
        {
            var entity = _mapper.Map<PoliticaPublicaEntity>(politica);
            return await _repository.InsertAsync(entity);
        }

        public async Task<PoliticaPublicaEntity> Put(PoliticaPublicaDtoUpdate politica)
        {
            var entity = _mapper.Map<PoliticaPublicaEntity>(politica);
            return await _repository.UpdateAsync(entity);
        }
    }
}
