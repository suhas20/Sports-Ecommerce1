using Business_Layer.Iservice;
using Microsoft.AspNetCore.Mvc;

namespace Sports_Ecommerce1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public ActionResult PlaceOrder()
        {
            var username = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = username;
            var Response = _orderService.PlaceOrder(username);
            if(Response == "Not Found")
            {
                ViewBag.message = "There was an internal error"; 
            }
            else if(Response == "Exceeded")
            {
                ViewBag.message = "The selected product exceeds the stock of the product.";
            }
            else
            {
                ViewBag.message = "your order has been placed";
            }
            return View();
        }
    }
}
