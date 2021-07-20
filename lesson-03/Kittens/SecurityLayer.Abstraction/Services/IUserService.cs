using System.IdentityModel.Tokens.Jwt;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SecurityLayer.Abstraction.Services
{
    public interface IUserService
    {
        string Authenticate(string user, string password);
    }
}
