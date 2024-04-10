using Business_Layer.Iservice;
using Microsoft.AspNetCore.Mvc;

namespace Sports_Ecommerce1.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly IFavouriteService _favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public ActionResult AddProduct(int id)
        {
            var username = HttpContext.Session.GetString("username");
            var data = _favouriteService.Add(id,username);
            return RedirectToAction("UserCart", "cart");
        }

        public ActionResult RemoveProduct(string id)
        {
            _favouriteService.Delete(id);
            return RedirectToAction("GetALLFavourites");

        }

        public ActionResult GetALLFavourites()
        {
            var username = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = username;
            var message = "Your cart is empty";
            ViewBag.MessageFav = message;
            var data = _favouriteService.Get(username);
            return View(data);
        }
    }
}
