using System.Threading.Tasks;
using SGM.Shared.Domain.Entities;
using SGM.Shared.Domain.Interfaces;

namespace SGM.Auth.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}