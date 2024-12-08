using System;
using System.Collections.Generic;

namespace Entities;

public partial class Product
{
    public int ProductsId { get; set; }

    public int CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Decripition { get; set; }

    public int Price { get; set; }

    public string? ImgPath { get; set; }

    public int? Quentity { get; set; }

    public virtual Category Category { get; set; } = null!;
}
