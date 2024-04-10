using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Iservice
{
    public interface IFavouriteService
    {
        string Add(int id, string username);
        void Delete(string id);
        List<Favourite> Get(string username);
    }
}
