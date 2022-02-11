using DataLayer.Abstraction.Entities;
using System.Threading.Tasks;

namespace DataLayer.Abstraction.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterNewUserAsync(string userName, byte[] passwordHash);

        Task<User> GetUserAsync(string userName, byte[] passwordHash);

        Task<User> GetUserAsync(string token);

        Task UpdateUserAsync(User user);
    }
}
