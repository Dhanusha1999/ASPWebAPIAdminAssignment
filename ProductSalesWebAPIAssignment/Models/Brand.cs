using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductSalesWebAPIAssignment.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? BrandName { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
