using Microsoft.EntityFrameworkCore;
using SGM.Gestao.Data.Mapping;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Data.Context
{
    public class SgmContextGestao : DbContext
    {
        public DbSet<VagaEntity> Vagas { get; set; }
        public DbSet<TreinamentoEntity> Treinamentos { get; set; }
        public DbSet<ColaboradorEntity> Coloboradores { get; set; }
        public DbSet<CandidatoVagaEntity> CandidatosVaga { get; set; }
        public SgmContextGestao(DbContextOptions<SgmContextGestao> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VagaEntity>(new VagaMap().Configure);
            modelBuilder.Entity<TreinamentoEntity>(new TreinamentoMap().Configure);
            modelBuilder.Entity<ColaboradorEntity>(new ColaboradorMap().Configure);
            modelBuilder.Entity<CandidatoVagaEntity>(new CandidatoVagaMap().Configure);
        }
    }
}