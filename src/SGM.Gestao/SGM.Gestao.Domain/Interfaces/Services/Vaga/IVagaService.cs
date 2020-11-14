using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Domain.Interfaces.Services.Vaga
{
    public interface IVagaService
    {
        Task<VagaEntity> Get(Guid id);
        Task<IEnumerable<VagaEntity>> GetAll();
        Task<VagaEntity> Post(VagaDtoCreate vaga);
        Task<VagaEntity> Put(VagaDtoUpdate vaga);
        Task<bool> Delete(Guid id);
    }
}