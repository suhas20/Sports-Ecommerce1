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
    public class CartService:ICartService
    {
        private readonly ICart cart;

        public CartService(ICart Cart)
        {
                cart = Cart;
        }

        public string AddProduct(int Id,string username)
        {
            return cart.AddtoCart(Id,username);
        }

        public List<Cart> GetAllCartItemsOfUser(string username)
        {
            return cart.GetcartItemsByUser(username);
        }

        public void removeproduct(string id)
        {
            cart.RemoveProduct(id);
        }

        public void UpdateQuantity(string id)
        {
            cart.UpdateQuantity(id);
        }
    }
}
