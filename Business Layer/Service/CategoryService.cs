using Business_Layer.Iservice;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryService _categoryService;
        public CategoryService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public string AddCategory(Category cat)
        {
            return _categoryService.AddCategory(cat);
        }

        public string AddSubcategory(SubCategory subcat)
        {
            return _categoryService.AddSubcategory(subcat);
        }

        public string DeleteCategory(int id)
        {
            return (_categoryService.DeleteCategory(id));
        }

        public string DeleteSubcategory(int id)
        {
            return _categoryService.DeleteSubcategory(id);
        }

        public List<Category> GetALLCategory()
        {
            return _categoryService.GetALLCategory();
        }

        public List<SubCategory> GetALLSubcategories()
        {
            return _categoryService.GetALLSubcategories();
        }

        public Category ViewCategory(int id)
        {
            return _categoryService.ViewCategory(id);
        }

        public SubCategory ViewSubcategory(int id)
        {
            return _categoryService.ViewSubcategory(id);
        }
    }
}
