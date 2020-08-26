using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SGM.Auth.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<AuthContext>
    {
        public AuthContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrations 
            var connectionString = "server=db;userid=root;password=456852;database=SGM_AUTH";
            var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
            optionsBuilder.UseMySql(connectionString);
            return new AuthContext(optionsBuilder.Options);
        }
    }
}