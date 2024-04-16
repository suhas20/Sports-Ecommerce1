using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.IRepository
{
    public interface IUser
    {
        /*User AddUser(User user);
        User UpdateUserById(int ID);
        List<User> GetAllUsers();
        User GetUserById(int ID);*/

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
