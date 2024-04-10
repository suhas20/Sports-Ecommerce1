using Data_Layer.Data;
using Data_Layer.IRepository;
using Data_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class CartRepo : ICart
    {
        private readonly SportsEcommerceContext _context;

        public CartRepo(SportsEcommerceContext context)
        {
            _context = context;
        }

        public string AddtoCart(int id, string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                // User not found, handle the error or return an appropriate response
                return "User not found";
            }

            var userId = user.UserId;
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if(product == null) return null;

            // Retrieve existing cart from session or create a new one
            var existingdata = GetProductByUserID(userId,id);
            if (existingdata != null)
            {
                existingdata.Quantity++;
            }
            else
            {
                Cart cartItem = new Cart()
                {
                    CartId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    UserId = userId,
                    ProductName = product.ProductName,
                    Quantity = 1,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                };
                _context.Add(cartItem);
            }
            
            _context.SaveChanges();
            return "";
        }



        public List<Product> GetAllCartItems()
        {
            throw new NotImplementedException();
        }

        private Cart GetProductByUserID(string userID, int productID)
        {
            var data = _context.Carts.FirstOrDefault(x => x.UserId == userID && x.ProductId == productID);
            return data;
        }

        public void RemoveProduct(string id)
        {
            var data = _context.Carts.FirstOrDefault(x => x.CartId == id);
            _context.Remove(data);
            _context.SaveChanges();
        }

        public List<Cart>? GetcartItemsByUser(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username);
            if(user == null) return null;
            var userId = user.UserId;

            var cartItems = _context.Carts.Where(x => x.UserId == userId).ToList();
            return cartItems;
        }

        public void UpdateQuantity(string id)
        {
            var data = _context.Carts.FirstOrDefault(x => x.CartId == id);
            var cartQuantity = data.Quantity;

            if(cartQuantity == 1)
            {
                RemoveProduct(id);
            }
            else
            {
                data.Quantity--;
                _context.SaveChanges(); 
            }
        }
    }
}
