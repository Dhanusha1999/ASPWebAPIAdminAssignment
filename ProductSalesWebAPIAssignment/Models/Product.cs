using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductSalesWebAPIAssignment.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? BrandId { get; set; }

    public int? CategoryId { get; set; }

    public int? ModelYear { get; set; }

    public int? ListPrice { get; set; }
    [JsonIgnore]

    public virtual Brand? Brand { get; set; }
    [JsonIgnore]

    public virtual Category? Category { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
