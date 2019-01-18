using ExperimentsApp.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IUserService
    {
        bool AuthenticateUser(User user, string password);
        Task<IList<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> FindUserByUsernameAsync(string username);
        Task CreateUserAsync(User user, string password);
        Task DeleteUserAsync(User user);
        Task<bool> SaveChangesAsync();
        object GenerateToken(User user);
    }
}
 