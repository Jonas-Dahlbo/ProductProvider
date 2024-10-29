using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Review
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? Product_id { get; set; }

    public int? Stars { get; set; }

    public string? Text { get; set; }

    public virtual Product? Product { get; set; }
}
