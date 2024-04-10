using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.IRepository
{
    public interface IFavourite
    {
        string Addtofavourite(int id, string username);
        void RemoveProductFromfavourite(string id);
        List<Favourite> GetFavouritesByUser(string username);
    }
}
