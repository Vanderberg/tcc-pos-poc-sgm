using System.Threading.Tasks;
using SGM.Auth.Domain.Dtos;

namespace SGM.Auth.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}