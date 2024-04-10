using Microsoft.AspNetCore.Mvc;
using Sports_Ecommerce1.Models;
using System.Diagnostics;

namespace Sports_Ecommerce1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult mainView()
        {
            var sessiondata = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = sessiondata;
            return View();
        }
        public IActionResult Index()
        {
            var sessiondata = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = sessiondata;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}