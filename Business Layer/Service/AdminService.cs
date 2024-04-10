using Business_Layer.Iservice;
using Data_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdmin _admin;

        public AdminService(IAdmin admin)
        {
            _admin = admin;
        }
        public string Login(string username, string password)
        {
            return _admin.Login(username, password);
        }
    }
}
