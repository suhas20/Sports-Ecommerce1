using Business_Layer.Iservice;
using Data_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sports_Ecommerce1.Controllers
{
    public class DummyController : Controller
    {
        private readonly IProductService _productService;

        public DummyController(IProductService productService)
        {
            _productService = productService;
        }
        
        // GET: DummyController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: DummyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DummyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DummyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Helper collection)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DummyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DummyController/Edit/5
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

        // GET: DummyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DummyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
