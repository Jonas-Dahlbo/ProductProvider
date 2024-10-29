using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Warehouse
{
    public int Unique_product_id { get; set; }

    public int? Product_id { get; set; }

    public int? Color_id { get; set; }

    public int? Size_id { get; set; }

    public int? Current_stock { get; set; }

    public virtual Color? Color { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
