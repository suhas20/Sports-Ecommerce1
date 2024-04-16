using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Iservice
{
    public interface IUserService
    {
        User GetUser();
        void Register(User user);
        string Login(string username, string password);
        void Logout();
        User GetUser(string username);
        void updateUser(User user);
        User RegisterUser(User user);
        User GetUserDetails(string username);
    }
}
