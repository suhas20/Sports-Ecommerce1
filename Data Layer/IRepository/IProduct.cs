using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.IRepository
{
    public interface IProduct
    {
        string CreateProduct(Product product);
        Product GetProductByID(int ID);
        Task<List<Product>> GetAllProducts();
        IEnumerable<Product> GetproductsByCategory(string categoryName, string category, int? page);
        Product ViewproductDetails(int productID);
        string DeleteProduct(int id);
        string EditProduct(Product product);
    }
}
