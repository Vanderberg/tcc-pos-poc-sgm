using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SGM.Auth.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<SgmContext>
    {
        public SgmContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrations 
            var connectionString = "server=127.0.0.1;userid=root;password=456852;database=SGM_AUTH";
            var optionsBuilder = new DbContextOptionsBuilder<SgmContext>();
            optionsBuilder.UseMySql(connectionString);
            return new SgmContext(optionsBuilder.Options);
        }
    }
}