using SGM.Gestao.Data.Context;

namespace SGM.Gestao.CrossCutting.DependencyInjection
{
    public class ConfigureSeed
    {
        private readonly SgmContextGestao _context;
        
        public ConfigureSeed(SgmContextGestao context)
        {
            _context = context;
        }
        
        public void Seed()
        {
        }

    }
}