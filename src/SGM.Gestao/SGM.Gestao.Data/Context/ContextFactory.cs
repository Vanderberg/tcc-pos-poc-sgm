using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SGM.Gestao.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<SgmContextGestao>
    {
        public SgmContextGestao CreateDbContext(string[] args)
        {
            //Usado para criar as migrations 
            var connectionString = "server=127.0.0.1;userid=root;password=456852;database=SGM_GESTAO";
            var optionsBuilder = new DbContextOptionsBuilder<SgmContextGestao>();
            optionsBuilder.UseMySql(connectionString);
            return new SgmContextGestao(optionsBuilder.Options);
        }
    }
}