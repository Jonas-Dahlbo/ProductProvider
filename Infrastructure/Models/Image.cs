using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Image
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public int? Product_id { get; set; }

    public string? Image_URL { get; set; }

    public virtual Product? Product { get; set; }
}
