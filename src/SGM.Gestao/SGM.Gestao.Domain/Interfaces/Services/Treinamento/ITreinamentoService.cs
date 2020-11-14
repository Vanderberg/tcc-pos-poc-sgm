using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Domain.Interfaces.Services.Treinamento
{
    public interface ITreinamentoService
    {
        Task<TreinamentoEntity> Get(Guid id);
        Task<IEnumerable<TreinamentoEntity>> GetAll();
        Task<TreinamentoEntity> Post(TreinamentoDtoCreate treinamento);
        Task<TreinamentoEntity> Put(TreinamentoDtoUpdate treinamento);
        Task<bool> Delete(Guid id);
    }
}