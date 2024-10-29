using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Category
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? Name { get; set; }

    public string? Icon { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
