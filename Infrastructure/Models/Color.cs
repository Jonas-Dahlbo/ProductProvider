using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Color
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Hexadecimal_color { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
