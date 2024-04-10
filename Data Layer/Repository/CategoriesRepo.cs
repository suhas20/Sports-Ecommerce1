using Data_Layer.Data;
using Data_Layer.IRepository;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class CategoriesRepo : ICategories
    {
        private readonly SportsEcommerceContext _context;

        public CategoriesRepo(SportsEcommerceContext context)
        {
            _context = context;
        }

        public string AddCategory(Category cat)
        {
            var newCategory = new Category
            {
                CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return "Ok";
        }

        public string AddSubcategory(SubCategory subcat)
        {
            var newSubcategory = new SubCategory
            {
                SubcategoryID = subcat.SubcategoryID,
                categoryID = subcat.categoryID,
                SubCategoryName = subcat.SubCategoryName
            };
            _context.SubCategories.Add(newSubcategory);
            _context.SaveChanges();
            return "Ok";
        }

        public string DeleteCategory(int id)
        {
            var data = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (data == null) return "NotFound";
            _context.Categories.Remove(data);
            _context.SaveChanges();
            return "Ok";
        }

        public string DeleteSubcategory(int id)
        {
            var data = _context.SubCategories.FirstOrDefault(x => x.SubcategoryID == id);
            if (data == null) return "NotFound";
            _context.SubCategories.Remove(data);
            _context.SaveChanges();
            return "Ok";
        }

        public List<Category> GetALLCategory()
        {
            return _context.Categories.ToList();
        }

        public List<SubCategory> GetALLSubcategories()
        {
            return _context.SubCategories.ToList();
        }

        public Category ViewCategory(int id)
        {
            var data = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (data == null) return null;
            return data;
        }

        public SubCategory ViewSubcategory(int id)
        {
            var data = _context.SubCategories.FirstOrDefault(x => x.SubcategoryID  == id);
            if (data == null) return null;
            return data;
        }
    }
}
