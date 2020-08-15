using System.Threading.Tasks;
using SGM.Auth.Domain.Entities;
using SGM.Auth.Domain.Interfaces;

namespace SGM.Auth.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}