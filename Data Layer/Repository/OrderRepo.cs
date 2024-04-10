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
    public class OrderRepo : IOrders
    {
        private readonly SportsEcommerceContext _Context;

        public OrderRepo(SportsEcommerceContext context)
        {
            _Context = context;
        }
        public string PlaceOrder(string username)
        {
            var user = _Context.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null) return "Not Found";
            var userId = user.UserId;
            List<Cart> cartItems = _Context.Carts.Where(x => x.UserId == userId).ToList();
            foreach(Cart cart in cartItems)
            {
                var product = _Context.Products.FirstOrDefault(x => x.ProductId == cart.ProductId);
                if (product == null) return "Not Found";
                var productStock = product.Stock;
                if(cart.Quantity < productStock)
                {
                    product.Stock--;
                    _Context.Carts.Remove(cart);
                    _Context.SaveChanges();
                }
                else
                {
                    return "Exceeded";
                }
            }

            return "Ok";
        }
    }
}
