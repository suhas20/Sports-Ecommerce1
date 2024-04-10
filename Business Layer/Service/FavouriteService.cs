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
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavourite _favrepo;

        public FavouriteService(IFavourite favrepo)
        {
            _favrepo = favrepo;
        }

        public string Add(int id, string username)
        {
            return _favrepo.Addtofavourite(id, username);
        }

        public void Delete(string id)
        {
            _favrepo.RemoveProductFromfavourite(id);
        }

        public List<Favourite> Get(string username)
        {
            return _favrepo.GetFavouritesByUser(username);
        }
    }
}
