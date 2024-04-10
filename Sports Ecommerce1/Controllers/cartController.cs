using Business_Layer.Iservice;
using Data_Layer.Models;
using Data_Layer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sports_Ecommerce1.Controllers
{
    public class cartController : Controller
    {
        private readonly ICartService _cartService;

        public cartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        // GET: cartController
        public ActionResult Index()
        {
            var cartitem = HttpContext.Session.GetObjectFromJson<List<Cart>>("Cart") ?? new List<Cart>();
            return View(cartitem);
        }

        public ActionResult AddTocart(int id)
        {
            var username = HttpContext.Session.GetString("username");
            var result = _cartService.AddProduct(id,username);
            return RedirectToAction("UserCart");

        }
        public ActionResult decrementQuantity(string id)
        {
            _cartService.UpdateQuantity(id);
            return RedirectToAction("UserCart");
        }

        // GET: cartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: cart items of particullar user
        public ActionResult UserCart()
        {
            var username = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = username;
            var data = _cartService.GetAllCartItemsOfUser(username);
            var message = "Your cart is empty";
            ViewBag.Message = message;
            return View(data);
        }

        // GET: cartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: cartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: cartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: cartController/Delete/5
        public ActionResult Delete(string id)
        {
            _cartService.removeproduct(id);
            return RedirectToAction("UserCart");
        }

       
    }
}
