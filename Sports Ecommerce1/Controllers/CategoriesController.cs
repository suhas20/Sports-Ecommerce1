using Business_Layer.Iservice;
using Business_Layer.Service;
using Data_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sports_Ecommerce1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult CList()
        {
            var data = _categoryService.GetALLCategory();
            return View(data);
        }

        public ActionResult AddC(Category cat)
        {
            var res = _categoryService.AddCategory(cat);
            if(res != "Ok") return View();
            return RedirectToAction("CList");
        }

        public ActionResult DeleteC(int id)
        {
            var res = _categoryService.DeleteCategory(id);
            if (res != "Ok") return View();
            return RedirectToAction("CList");
        }

        public ActionResult CDetail(int id)
        {
            var data = _categoryService.ViewCategory(id);
            if(data != null )return View(data);
            return RedirectToAction("CLsit");
        }

        public ActionResult SList()
        {
            var data = _categoryService.GetALLSubcategories();
            return View(data);
        }

        public ActionResult AddS(SubCategory scat)
        {
            var res = _categoryService.AddSubcategory(scat);
            if (res != "Ok") return View();
            return RedirectToAction("SList");
        }

        public ActionResult DeleteS(int id)
        {
            var res = _categoryService.DeleteSubcategory(id);
            if (res != "Ok") return View();
            return RedirectToAction("SList");
        }

        public ActionResult SDetail(int id)
        {
            var data = _categoryService.ViewSubcategory(id);
            if (data != null) return View(data);
            return RedirectToAction("CLsit");
        }

        public ActionResult GetCategoryByID(int id)
        {
            return View();
        }
        public ActionResult GetSubCategoryByID(int id)
        {
            return View();
        }

    }
}
