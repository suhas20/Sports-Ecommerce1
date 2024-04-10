using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class User
{
    public string UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Favourite> Favourites { get; set; } =  new List<Favourite>();
}
