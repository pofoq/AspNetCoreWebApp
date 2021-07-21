using BusinessLayer.Abstraction.Dto;
using BusinessLayer.Abstraction.Services;
using DataLayer.Abstraction.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public sealed class UserService : IUserService
    {
        public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<TokenResponse> AuthenticateAsync(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var user = await _repository.GetUserAsync(userName, GetPasswordHash(password));

            if (user is null)
            {
                return null;
            }

            var userDto = Mapper.Map(user);

            var response = new TokenResponse();

            response.Token = GenerateJwtToken(userDto.Id, 15);
            var refreshToken = GenerateRefreshToken(userDto.Id);

            response.RefreshToken = refreshToken.Token;
            userDto.RefreshToken = refreshToken;

            await _repository.UpdateUserAsync(Mapper.Map(userDto));

            return response;
        }

        public async Task<string> RefreshToken(string oldToken)
        {
            var user = await _repository.GetUserAsync(oldToken);
            if (user is null)
            {
                return string.Empty;
            }
            var userDto = Mapper.Map(user);
            if (!userDto.RefreshToken.IsExpired)
            {
                userDto.RefreshToken = GenerateRefreshToken(userDto.Id);
                await _repository.UpdateUserAsync(Mapper.Map(userDto));
                return userDto.RefreshToken.Token;
            }
            return string.Empty;
        }

        public RefreshToken GenerateRefreshToken(int id)
        {
            RefreshToken refreshToken = new RefreshToken();
            refreshToken.Expires = DateTime.Now.AddMinutes(360);
            refreshToken.Token = GenerateJwtToken(id, 360);
            return refreshToken;
        }

        private string GenerateJwtToken(int id, int expires)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }

        public async Task<bool> RegisterNewUserAsync(string userName, string password)
        {
            var user = await _repository.RegisterNewUserAsync(userName, GetPasswordHash(password));
            return user != null;
        }
    }

}
