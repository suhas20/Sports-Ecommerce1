using Business_Layer.Iservice;
using Data_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace Sports_Ecommerce1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: Product
        public async Task<ActionResult> Index()
        {
            List<Product> List = await _productService.GetAllProducts();
            return View(List);
        }


        public async Task<ActionResult> GetAllProducts()
        {
            List<Product> List = await _productService.GetAllProducts();
            return View(List);
        }

        public  ActionResult GetProductsByCategory(string categoryName,string category, int? page)
        {
            var sessiondata = HttpContext.Session.GetString("username");
            ViewBag.Sessiondata = sessiondata;
            var products =  _productService.GetProductByCategory(categoryName,category,page);
            return View("GetAllProducts", products.ToPagedList(page ?? 1, 9));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var data = _productService.ProductDetails(id);
            return View(data);
        }
        public ActionResult GetProductById()
        {
            return View();
        }
        

        public ActionResult ADetails(int id)
        {
            var data = _productService.ProductDetails(id);
            return View(data);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            var data = _productService.create(product);
            if( data == "Ok") return RedirectToAction("Index");
            return View();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _productService.GetProdById(id);
            return View(data);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var res = _productService.update(product);
            if(res == "Ok")return RedirectToAction("Index");
            return View();
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var res = _productService.delete(id);
            return RedirectToAction("Index");
        }

    }
}
