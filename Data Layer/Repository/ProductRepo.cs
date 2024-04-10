using Data_Layer.Data;
using Data_Layer.IRepository;
using Data_Layer.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly SportsEcommerceContext _context;

        public ProductRepo(SportsEcommerceContext context)
        {
            _context = context;
        }

        public string CreateProduct(Product product)
        {
            var randomID = new Random();
            Product newProd = new Product
            {

                ProductId = randomID.Next(),
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                Category = product.Category,
                Stock = product.Stock,
                SubCategory = product.SubCategory,
                IsActive = product.IsActive,
                ImageUrl = product.ImageUrl
            };
            _context.Products.Add(newProd);
            _context.SaveChanges();

            return "Ok";
        }

        public string DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null) return "NotFound";
            _context.Products.Remove(product);
            _context.SaveChanges();
            return "Ok";
        }

        public string EditProduct(Product product)
        {
            var data = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

            if(data != null)
            {
                data.ProductName = product.ProductName;
                data.Price = product.Price;
                data.Description = product.Description;
                data.Quantity = product.Quantity;
                data.Category = product.Category;
                data.Stock = product.Stock;
                data.SubCategory = product.SubCategory;
                data.IsActive = product.IsActive;
                data.ImageUrl = product.ImageUrl;
                _context.SaveChanges();
                return "Ok";
            }
            return "null";
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public Product GetProductByID(int ID)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == ID);
            if (product == null) return null;
            return product;
        }

        public  IEnumerable<Product> GetproductsByCategory(string categoryName, string category, int? page)
        {
            return  _context.Products.Where(p => p.SubCategory1.SubCategoryName == categoryName
                                            && p.Category1.CategoryName == category).ToList();
        }

        public Product ViewproductDetails(int productID)
        {
            var prod = _context.Products.Where(x => x.ProductId == productID).FirstOrDefault();
            return prod;
        }
    }
}
