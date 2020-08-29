using Microsoft.EntityFrameworkCore;
using SGM.Cidadao.Data.Mapping;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Data
{
    public class SgmContext : DbContext
    {
        public DbSet<PoliticaPublica> Users { get; set; }
        public SgmContext(DbContextOptions<SgmContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PoliticaPublica>(new PoliticaPublicaMap().Configure);
        }
    }
}