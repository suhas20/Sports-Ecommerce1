using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.IRepository
{
    public interface IAdmin
    {
        Admin AddAdmin(Admin admin);
        void UpdateAdminByID(int ID);
        string Login(string username, string password);
    }
}
