using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Size
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
