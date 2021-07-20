
namespace BusinessLayer.Abstraction.Services
{
    public interface IUserService
    {
        string Authenticate(string user, string password);
    }
}
