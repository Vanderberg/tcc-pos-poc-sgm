using AutoMapper;
using SGM.Cidadao.Domain.Dtos;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Interfaces.Services.PoliticaPublica;
using SGM.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PoliticaPublicaDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<PoliticaPublicaDto>(entity) ?? new PoliticaPublicaDto();
        }

        public async Task<IEnumerable<PoliticaPublicaDto>> GetAll()
        {
            var listentity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PoliticaPublicaDto>>(listentity);
        }

        public async Task<PoliticaPublicaDto> Post(PoliticaPublicaDto politica)
        {
            var entity = _mapper.Map<PoliticaPublicaEntity>(politica);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PoliticaPublicaDto>(result);
        }

        public async Task<PoliticaPublicaDto> Put(PoliticaPublicaDto politica)
        {
            var entity = _mapper.Map<PoliticaPublicaEntity>(politica);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<PoliticaPublicaDto>(result);
        }
    }
}
