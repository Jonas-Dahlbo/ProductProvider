using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Size
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? Name { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
