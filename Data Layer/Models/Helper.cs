using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Helper
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public int ProductID { get; set; }
        public bool IsActive { get; set; } 
        public string Brand { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
