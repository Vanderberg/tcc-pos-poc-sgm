using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Dtos;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Domain.Interfaces.Services.Campanha
{
    public interface ICampanhaService
    {
        Task<CampanhaEntity> Get(Guid id);
        Task<IEnumerable<CampanhaEntity>> GetAll();
        Task<CampanhaEntity> Post(CampanhaDtoCreate campanha);
        Task<CampanhaEntity> Put(CampanhaDtoUpdate campanha);
        Task<bool> Delete(Guid id);
    }
}