using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductSalesWebAPIAssignment.Models;

public partial class OrderItem
{
    public int? OrderId { get; set; }

    public int ItemId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? ListPrice { get; set; }

    public int? Discount { get; set; }
    [JsonIgnore]

    public virtual Order? Order { get; set; }
    [JsonIgnore]

    public virtual Product? Product { get; set; }
}
