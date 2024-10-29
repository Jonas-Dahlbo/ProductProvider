using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Warehouse
{
    public string Unique_product_id { get; set; } = Guid.NewGuid().ToString();

    public string? Product_id { get; set; }

    public string? Color_id { get; set; }

    public string? Size_id { get; set; }

    public string? Current_stock { get; set; }

    public virtual Color? Color { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
