using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;
using SGM.Gestao.Domain.Interfaces.Services.Colaborador;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Gestao.Service.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private IRepository<ColaboradorEntity> _repository;
        private readonly IMapper _mapper;

        public ColaboradorService(IRepository<ColaboradorEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;      
        }
        
        public async Task<ColaboradorEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id); 
        }

        public async Task<IEnumerable<ColaboradorEntity>> GetAll()
        {
            return await _repository.SelectAsync(); 
        }

        public async Task<ColaboradorEntity> Post(ColaboradorDtoCreate colaborador)
        {
            var entity = _mapper.Map<ColaboradorEntity>(colaborador);
            return await _repository.InsertAsync(entity);
        }

        public async Task<ColaboradorEntity> Put(ColaboradorDtoUpdate colaborador)
        {
            var entity = _mapper.Map<ColaboradorEntity>(colaborador);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}