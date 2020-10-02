using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Domain.Interfaces.Services.Campanha
{
    public interface ICampanhaService
    {
        Task<CampanhaEntity> Get(Guid id);
        Task<IEnumerable<CampanhaEntity>> GetAll();
        Task<CampanhaEntity> Post(CampanhaEntity campanha);
        Task<CampanhaEntity> Put(CampanhaEntity campanha);
        Task<bool> Delete(Guid id);
    }
}