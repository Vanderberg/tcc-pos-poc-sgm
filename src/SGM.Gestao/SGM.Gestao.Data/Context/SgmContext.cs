using Microsoft.EntityFrameworkCore;
using SGM.Gestao.Data.Mapping;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Data
{
    public class SgmContextGestao : DbContext
    {
        public DbSet<VagaEntity> Vagas { get; set; }
        public DbSet<TreinamentoEntity> Treinamentos { get; set; }
        public DbSet<ColaborardorEntity> Coloboradores { get; set; }
        public SgmContextGestao(DbContextOptions<SgmContextGestao> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VagaEntity>(new VagaMap().Configure);
            modelBuilder.Entity<TreinamentoEntity>(new TreinamentoMap().Configure);
            modelBuilder.Entity<ColaborardorEntity>(new ColaboradorMap().Configure);
        }
    }
}