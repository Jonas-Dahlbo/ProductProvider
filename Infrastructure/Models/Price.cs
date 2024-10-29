using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Price
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? Product_id { get; set; }

    public decimal? Price1 { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Discount_price { get; set; }

    public DateTime? Start_date { get; set; }

    public DateTime? End_date { get; set; }

    public bool? IsActive { get; set; }

    public virtual Product? Product { get; set; }
}
