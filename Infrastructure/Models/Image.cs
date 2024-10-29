using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Image
{
    public int Id { get; set; }

    public int? Product_id { get; set; }

    public string? Image_URL { get; set; }

    public virtual Product? Product { get; set; }
}
