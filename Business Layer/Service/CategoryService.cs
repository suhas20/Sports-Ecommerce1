using Business_Layer.Iservice;
using Data_Layer.IRepository;
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
        private readonly ICategories _categories;
        public CategoryService(ICategories categories)
        {
            _categories = categories;
        }
        
        public string AddCategory(Category cat)
        {
            return _categories.AddCategory(cat);
        }

        public string AddSubcategory(SubCategory subcat)
        {
            return _categories.AddSubcategory(subcat);
        }

        public string DeleteCategory(int id)
        {
            return _categories.DeleteCategory(id);
        }

        public string DeleteSubcategory(int id)
        {
            return _categories.DeleteSubcategory(id);
        }

        public List<Category> GetALLCategory()
        {
            return _categories.GetALLCategory();
        }

        public List<SubCategory> GetALLSubcategories()
        {
            return _categories.GetALLSubcategories();
        }

        public Category ViewCategory(int id)
        {
            return _categories.ViewCategory(id);
        }

        public SubCategory ViewSubcategory(int id)
        {
            return _categories.ViewSubcategory(id);
        }
    }
}
