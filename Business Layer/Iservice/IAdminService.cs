﻿using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Iservice
{
    public interface IAdminService
    {
        string Login(string username, string password);
        string Add(Admin admin);
    }
}
