using Business_Layer.Iservice;
using Data_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sports_Ecommerce1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }
        public ActionResult AdminDashboard()
        {
            var sessiondata = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = sessiondata;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(IFormCollection model)
        {
            var username = model["username"]; 
            var password = model["password"];
            var res = _service.Login(username,password);
            HttpContext.Session.SetString("username", username);
            if (res == "Ok")
            {
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                ViewBag.message = "Invalid Password or username";
            }
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Admin admin)
        {
            var res = _service.Add(admin);
            if (res != "Ok") return View();
            var message = "New admin Added";
            ViewBag.message = message;
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.SetString("username", "null");
            return RedirectToAction("Index", "Home");
        }
    }
}
