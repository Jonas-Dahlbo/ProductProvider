using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? Name { get; set; }

    public string? Short_description { get; set; }

    public string? Long_description { get; set; }

    public string? Category_id { get; set; }

    public DateTime? Created_at { get; set; } 

    public bool? IsTopseller { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
