using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Iservice
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        IEnumerable<Product> GetProductByCategory(string categoryName,string category, int? page);
        Product ProductDetails(int id);
        string create(Product product);
        Product GetProdById(int id);
        string delete(int id);
        string update(Product product);

    }
}
