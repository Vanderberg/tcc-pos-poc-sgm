using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGM.Cidadao.Data.Context;
using SGM.Cidadao.Data.Repository;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Repository;

namespace SGM.Cidadao.Data.Implementations
{
    public class PoliticaPublicaImplementation : BaseRepository<PoliticaPublicaEntity>, IPoliticaPublicaRepository
    {
        private DbSet<PoliticaPublicaEntity> _dataset;
        
        public PoliticaPublicaImplementation(SgmContextCidadao context) : base(context)
        {
            _dataset = context.Set<PoliticaPublicaEntity>();
        }
        
        public async Task<PoliticaPublicaEntity> FindByTitulo(string titulo)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Titulo.Equals(titulo));
        }
    }
}