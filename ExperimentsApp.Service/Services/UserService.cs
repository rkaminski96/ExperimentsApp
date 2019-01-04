using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Helpers;
using ExperimentsApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ExperimentsApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public UserService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public User AuthenticateUser (string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _experimentsDbContext.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            var passwordHash = PasswordHasher.HashPassword(password, user.PasswordSalt);
            if (!user.PasswordHash.Equals(passwordHash))
                return null;

            return user;
        }

        public List<User> GetAll()
        {
            return _experimentsDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            User foundUser = _experimentsDbContext.Users
                .Where(user => user.Id == id)
                .SingleOrDefault();

            return foundUser;
        }

        public User Create(User user, string password)
        {
            new RNGCryptoServiceProvider().GetBytes(user.PasswordSalt = new byte[32]);
            user.PasswordHash = PasswordHasher.HashPassword(password, user.PasswordSalt);

            _experimentsDbContext.Users.Add(user);
            _experimentsDbContext.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var user = _experimentsDbContext.Users.Find(id);
            if (user != null)
            {
                _experimentsDbContext.Users.Remove(user);
                _experimentsDbContext.SaveChanges();
            }
        }


    }
}
