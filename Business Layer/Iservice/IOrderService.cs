using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Iservice
{
    public interface IOrderService
    {
        string PlaceOrder(string username);
    }
}
