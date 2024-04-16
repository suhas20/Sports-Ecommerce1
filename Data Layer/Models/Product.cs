using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public int Category { get; set; } 

    public int Stock { get; set; }
    public int SubCategory { get; set; }
    public bool IsActive { get; set; }
    public string ImageUrl { get; set; } = null!;

    public virtual Category Category1 { get; set; } = null!;
    public virtual SubCategory SubCategory1 { get; set; } = null!;


    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
}
