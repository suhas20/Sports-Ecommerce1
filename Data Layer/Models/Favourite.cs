using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class Favourite
{
    public string FavouriteId { get; set; }

    public int ProductId { get; set; }

    public string UserId { get; set; }
    public string ProductImage { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
