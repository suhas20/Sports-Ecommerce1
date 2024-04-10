using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public partial  class SubCategory
    {
        public int SubcategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int categoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
