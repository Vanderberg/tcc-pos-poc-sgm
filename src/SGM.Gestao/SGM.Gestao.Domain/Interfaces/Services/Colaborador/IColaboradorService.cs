using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Domain.Interfaces.Services.Colaborador
{
    public interface IColaboradorService
    {
        Task<ColaboradorEntity> Get(Guid id);
        Task<IEnumerable<ColaboradorEntity>> GetAll();
        Task<ColaboradorEntity> Post(ColaboradorDtoCreate colaborador);
        Task<ColaboradorEntity> Put(ColaboradorDtoUpdate colaborador);
        Task<bool> Delete(Guid id);
    }
}