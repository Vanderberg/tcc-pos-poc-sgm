using Microsoft.EntityFrameworkCore;
using SGM.Cidadao.Data.Mapping;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Data.Context
{
    public class SgmContextCidadao : DbContext
    {
        public DbSet<PoliticaPublicaEntity> PoliticaPublicas { get; set; }
        public SgmContextCidadao(DbContextOptions<SgmContextCidadao> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PoliticaPublicaEntity>(new PoliticaPublicaMap().Configure);
        }
    }
}