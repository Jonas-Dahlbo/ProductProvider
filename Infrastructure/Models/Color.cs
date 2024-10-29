using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Color
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? Name { get; set; }

    public string? Hexadecimal_color { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
