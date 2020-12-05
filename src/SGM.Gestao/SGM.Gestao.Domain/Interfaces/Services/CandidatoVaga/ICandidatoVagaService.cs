using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Domain.Interfaces.Services.CandidatoVaga
{
    public interface ICandidatoVagaService
    {
        Task<CandidatoVagaEntity> Get(Guid id);
        Task<IEnumerable<CandidatoVagaEntity>> GetAll();
        Task<CandidatoVagaEntity> Post(CanditatoDtoCreate campanha);
        Task<CandidatoVagaEntity> Put(CandidatoDtoUpdate campanha);
        Task<bool> Delete(Guid id);
    }
}