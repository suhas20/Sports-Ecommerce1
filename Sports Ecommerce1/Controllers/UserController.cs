using Business_Layer.Iservice;
using Data_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Sports_Ecommerce1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //get account 
        public ActionResult Index()
        {
            var usr = _service.GetUser();
            return View(usr);
        }

        //register user
        [HttpPost]
        public ActionResult register(User user)
        {
            if (ModelState.IsValid)
            {
                _service.Register(user);
                HttpContext.Session.SetString("username", user.UserName);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(IFormCollection form)
        {
            string username = form["username"];
            string password = form["password"];

            if (ModelState.IsValid)
            {
                var data = _service.Login(username, password);
                HttpContext.Session.SetString("username", username);
                if(data == "Ok")
                {
                    return RedirectToAction("mainView", "Home");
                }
                else
                {
                    ViewBag.message = "Invalid Password or username";
                }
                
            }
            return View();

        }

        //logout
        public ActionResult Logout()
        {
            _service.Logout();
            HttpContext.Session.SetString("username", "null");
            return RedirectToAction("Index", "Home");
        }

        //update user
        [HttpPost]
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                _service.updateUser(user);
                HttpContext.Session.SetString("username",user.UserName);
                return RedirectToAction("Index", "Home");
           }
            return View();
        }

        //create user

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
                var usr = _service.RegisterUser(user);
                if(usr != null)
                {
                    return RedirectToAction("Login", "User");
                }
            return View();
        }

        public ActionResult details(string username)
        {
            var sessiondata = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = sessiondata;
            var res = _service.GetUserDetails(username);
            return View(res);
        }
    }
}
