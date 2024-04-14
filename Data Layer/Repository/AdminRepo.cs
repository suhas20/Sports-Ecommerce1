using Data_Layer.Data;
using Data_Layer.IRepository;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class AdminRepo : IAdmin
    {
        private readonly SportsEcommerceContext _contex;

        public AdminRepo(SportsEcommerceContext contex)
        {
            _contex = contex;
        }

        public string AddAdmin(Admin admin)
        {
            var randomID = new Random();
            var newAdmin = new Admin
            {
                AdminId = randomID.Next(),
                AdminName = admin.AdminName,
                AdminUsername = admin.AdminUsername,
                AdminPassword = admin.AdminPassword,
                Email = admin.Email
            
            };
            _contex.Admins.Add(newAdmin);
            _contex.SaveChanges();

            return "Ok";
        }

        public string Login(string username, string password)
        {
            var data = _contex.Admins.FirstOrDefault(x => x.AdminUsername == username && x.AdminPassword == password);
            if(data == null)
            {
                return "NotFound";
            }
            return "Ok";
        }

        public void UpdateAdminByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
