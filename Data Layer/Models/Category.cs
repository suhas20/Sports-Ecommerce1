using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
