using Microsoft.EntityFrameworkCore;

namespace SGM.Cidadao.Data
{
    public class ContextFactory
    {
        public SgmContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrations 
            var connectionString = "server=127.0.0.1;userid=root;password=456852;database=SGM_CIDADAO";
            var optionsBuilder = new DbContextOptionsBuilder<SgmContext>();
            optionsBuilder.UseMySql(connectionString);
            return new SgmContext(optionsBuilder.Options);
        }
    }
}