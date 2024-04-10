using Business_Layer.Iservice;
using Data_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrders _orderService;

        public OrderService(IOrders orderService)
        {
            _orderService = orderService;
        }
        public string PlaceOrder(string username)
        {
            return _orderService.PlaceOrder(username);
        }
    }
}
