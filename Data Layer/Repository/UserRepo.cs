using Data_Layer.Data;
using Data_Layer.IRepository;
using Data_Layer.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer.Repository
{
    public class UserRepo : IUser
    {
        private readonly SportsEcommerceContext _context;

        public UserRepo(SportsEcommerceContext context)
        {
            _context = context;
        }

        public User GetUser()
        {
            return _context.Users.Find(Tempdata.UserID);

        }

        public User GetUser(string username)
        {
            var usr = (from u in _context.Users
                       where u.UserName == username
                       select u).FirstOrDefault();

            return usr;
        }

        public User GetUserDetails(string username)
        {
            var data = _context.Users.FirstOrDefault(x => x.UserName == username);
            return data;
        }

        public string Login(string username, string password)
        {
            var usr = (from u in _context.Users
                       where (u.UserName == username && u.UserPassword == password)
                       select u).SingleOrDefault();

            if (usr != null)
            {
                Tempdata.UserID = usr.UserId;
            }
            else
            {
                return "Not found";
            }
            return "Ok";
        }

        public void Logout()
        {
            Tempdata.UserID = null;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            Tempdata.UserID = GetUser(user.UserName).UserId;
        }

        public User RegisterUser(User user)
        {
            User u = new User
            {
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                UserEmail = user.UserEmail,
                UserId = Guid.NewGuid().ToString()
            };

            _context.Users.Add(u);
            _context.SaveChanges();
            return u;
        }

        public void updateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
