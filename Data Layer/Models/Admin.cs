using System;
using System.Collections.Generic;

namespace Data_Layer.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string AdminUsername { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AdminPassword { get; set; } = null!;
}
