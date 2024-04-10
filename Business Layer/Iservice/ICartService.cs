using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Iservice
{
    public interface ICartService
    {
        string AddProduct(int Id,string username);
        List<Cart> GetAllCartItemsOfUser(string username);
        void UpdateQuantity(string id);
        void removeproduct(string id);
    }
}
