using Business_Layer.Iservice;
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
    }
}
