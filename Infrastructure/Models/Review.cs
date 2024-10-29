using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Review
{
    public int Id { get; set; }

    public int? Product_id { get; set; }

    public int? Stars { get; set; }

    public string? Text { get; set; }

    public virtual Product? Product { get; set; }
}
