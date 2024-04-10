using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class Cart
{
    public string CartId { get; set; }

    public int ProductId { get; set; }

    public string UserId { get; set; }

    public string ProductName { get; set; } = null!;
    public string ImageUrl { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
