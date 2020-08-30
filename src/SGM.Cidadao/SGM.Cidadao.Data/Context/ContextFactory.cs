using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SGM.Cidadao.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<SgmContextCidadao>
    {
        public SgmContextCidadao CreateDbContext(string[] args)
        {
            //Usado para criar as migrations 
            var connectionString = "server=127.0.0.1;userid=root;password=456852;database=SGM_CIDADAO";
            var optionsBuilder = new DbContextOptionsBuilder<SgmContextCidadao>();
            optionsBuilder.UseMySql(connectionString);
            return new SgmContextCidadao(optionsBuilder.Options);
        }
    }
}