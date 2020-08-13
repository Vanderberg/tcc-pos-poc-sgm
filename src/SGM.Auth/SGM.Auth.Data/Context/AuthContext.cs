using Microsoft.EntityFrameworkCore;
using SGM.Auth.Data.Mapping;
using SGM.Auth.Domain.Entities;

namespace SGM.Auth.Data.Context
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}