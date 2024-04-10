﻿using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.IRepository
{
    public interface ICategories
    {
        string AddCategory(Category cat);
        string AddSubcategory(SubCategory subcat);
        string DeleteCategory(int id);
        string DeleteSubcategory(int id);
        List<Category> GetALLCategory();
        List<SubCategory> GetALLSubcategories();
        Category ViewCategory(int id);
        SubCategory ViewSubcategory(int id);

    }
}
