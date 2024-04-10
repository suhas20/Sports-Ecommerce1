using Data_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.IRepository
{
    public interface ICart
    {
        string AddtoCart(int id, string username);
        void RemoveProduct(string id);
        List<Product> GetAllCartItems();
        List<Cart> GetcartItemsByUser(string username);
        void UpdateQuantity(string username);
    }
}
