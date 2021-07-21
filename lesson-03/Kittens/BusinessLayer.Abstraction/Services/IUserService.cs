using BusinessLayer.Abstraction.Dto;
using System.Threading.Tasks;

namespace BusinessLayer.Abstraction.Services
{
    public interface IUserService
    {
        Task<TokenResponse> AuthenticateAsync(string user, string password);

        Task<string> RefreshToken(string token);

        Task<bool> RegisterNewUserAsync(string user, string password);
    }
}
