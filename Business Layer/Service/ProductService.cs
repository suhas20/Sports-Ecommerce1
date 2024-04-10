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
    public class ProductService : IProductService
    {
        private readonly IProduct repo;

        public ProductService(IProduct prod)
        {
            repo = prod;
        }

        public string create(Product product)
        {
            return repo.CreateProduct(product);
        }

        public string delete(int id)
        {
            return repo.DeleteProduct(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await repo.GetAllProducts();
        }

        public Product GetProdById(int id)
        {
            return repo.GetProductByID(id);
        }

        public IEnumerable<Product> GetProductByCategory(string categoryName, string category, int? page)
        {
            return repo.GetproductsByCategory(categoryName,category,page);
        }

        public Product ProductDetails(int id)
        {
            return repo.ViewproductDetails(id);
        }

        public string update(Product product)
        {
            return repo.EditProduct(product);
        }
    }
}
