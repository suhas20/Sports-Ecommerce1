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

        public Admin AddAdmin(Admin admin)
        {
            throw new NotImplementedException();
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
