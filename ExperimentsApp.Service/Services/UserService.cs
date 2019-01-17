using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Helpers;
using ExperimentsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public UserService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public bool AuthenticateUser (User user, string password)
        {
            var passwordHash = PasswordHasher.HashPassword(password, user.PasswordSalt);
            return user.PasswordHash.Equals(passwordHash);
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await _experimentsDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _experimentsDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> FindUserByUsernameAsync(string username)
        {
            var user = await _experimentsDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }

        public async Task CreateUserAsync(User user, string password)
        {
            new RNGCryptoServiceProvider().GetBytes(user.PasswordSalt = new byte[32]);
            user.PasswordHash = PasswordHasher.HashPassword(password, user.PasswordSalt);
            await _experimentsDbContext.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            _experimentsDbContext.Users.Remove(user);
            await Task.CompletedTask;
        }
    
        public async Task<bool> SaveChangesAsync()
        {
            return await _experimentsDbContext.SaveChangesAsync() >= 0;
        }

    }
}
