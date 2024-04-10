using Data_Layer.Data;
using Data_Layer.IRepository;
using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class FavouriteRepo : IFavourite
    {
        private readonly SportsEcommerceContext _context;

        public FavouriteRepo(SportsEcommerceContext context)
        {
            _context = context;
        }
    
        public string Addtofavourite(int id, string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                // User not found, handle the error or return an appropriate response
                return "Not Found";
            }

            var userId = user.UserId;
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return "Not Found";

            // Retrieve existing cart from session or create a new one
            var existingdata = GetProductByUserID(userId, id);
            if (existingdata != null)
            {
                return "Exist";
            }
            else
            {
                Favourite Item = new Favourite()
                {
                    FavouriteId = Guid.NewGuid().ToString(),
                    UserId = userId,
                    ProductId = id,
                    ProductName = product.ProductName,
                    ProductDescription = product.Description,
                    ProductImage = product.ImageUrl,
                    ProductPrice = product.Price
                };
                _context.Add(Item);
            }

            _context.SaveChanges();
            return "";
        }
        private Favourite GetProductByUserID(string userID, int productID)
        {
            var data = _context.Favourites.FirstOrDefault(x => x.UserId == userID && x.ProductId == productID);
            return data;
        }

        public List<Favourite> GetFavouritesByUser(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null) return null;
            var userId = user.UserId;

            var favourites = _context.Favourites.Where(x => x.UserId == userId).ToList();
            return favourites;
        }

        public void RemoveProductFromfavourite(string id)
        {
            var data = _context.Favourites.FirstOrDefault(x => x.FavouriteId == id);
            _context.Remove(data);
            _context.SaveChanges();
        }
    }
}
