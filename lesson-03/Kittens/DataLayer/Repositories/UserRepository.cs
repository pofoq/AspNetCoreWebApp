using DataLayer.Abstraction.Entities;
using DataLayer.Abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private ApplicationDataContext _context;

        public UserRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string userName, byte[] passwordHash)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == passwordHash);
        }

        public async Task<User> GetUserAsync(string token)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.RefreshToken == token);
        }

        public async Task<User> RegisterNewUserAsync(string userName, byte[] passwordHash)
        {
            var user = new User() { UserName = userName, PasswordHash = passwordHash };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
