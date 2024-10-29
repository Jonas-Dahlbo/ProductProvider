using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Short_description { get; set; }

    public string? Long_description { get; set; }

    public int? Category_id { get; set; }

    public byte[] Created_at { get; set; } = null!;

    public bool? IsTopseller { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
