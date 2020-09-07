using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.Cidadao.Domain.Dtos;

namespace SGM.Cidadao.Domain.Interfaces.Services.PoliticaPublica
{
    public interface IPoliticaPublicaService
    {
        Task<PoliticaPublicaDto> Get(Guid id);
        Task<IEnumerable<PoliticaPublicaDto>> GetAll();
        Task<PoliticaPublicaDto> Post(PoliticaPublicaDto politica);
        Task<PoliticaPublicaDto> Put(PoliticaPublicaDto politica);
        Task<bool> Delete(Guid id);
    }
}