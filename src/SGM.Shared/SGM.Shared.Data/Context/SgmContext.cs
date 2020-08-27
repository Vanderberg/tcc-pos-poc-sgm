using Microsoft.EntityFrameworkCore;
using SGM.Shared.Data.Mapping;
using SGM.Shared.Domain.Entities;

namespace SGM.Shared.Data.Context
{
    public class SgmContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public SgmContext(DbContextOptions<SgmContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}