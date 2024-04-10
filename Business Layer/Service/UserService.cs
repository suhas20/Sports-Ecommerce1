using Business_Layer.Iservice;
using Data_Layer.IRepository;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class UserService : IUserService
    {
        private readonly IUser _user;

        public UserService(IUser user)
        {
            _user = user;     
        }
        public User GetUser()
        {
            return _user.GetUser();
        }

        public User GetUser(string username)
        {
            return _user.GetUser(username);
        }

        public string Login(string username, string password)
        {
            return _user.Login(username, password);
        }

        public void Logout()
        {
            _user.Logout();
        }

        public void Register(User user)
        {
            _user.Register(user);
        }

        public User RegisterUser(User user)
        {
            return _user.RegisterUser(user);
        }

        public void updateUser(User user)
        {
            _user.updateUser(user);
        }
    }
}
