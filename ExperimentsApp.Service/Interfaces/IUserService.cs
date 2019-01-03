using ExperimentsApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IUserService
    {
        User AuthenticateUser (string username, string password);
        List<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Delete(int id);
    }
}
 