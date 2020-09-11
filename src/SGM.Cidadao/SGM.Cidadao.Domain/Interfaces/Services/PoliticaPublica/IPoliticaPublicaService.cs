using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Domain.Interfaces.Services.PoliticaPublica
{
    public interface IPoliticaPublicaService
    {
        Task<PoliticaPublicaEntity> Get(Guid id);
        Task<IEnumerable<PoliticaPublicaEntity>> GetAll();
        Task<PoliticaPublicaEntity> Post(PoliticaPublicaEntity politica);
        Task<PoliticaPublicaEntity> Put(PoliticaPublicaEntity politica);
        Task<bool> Delete(Guid id);
    }
}