using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGM.Auth.Data.Context;
using SGM.Auth.Data.Repository;
using SGM.Auth.Domain.Entities;
using SGM.Auth.Domain.Repository;

namespace SGM.Auth.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(AuthContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

    }
}