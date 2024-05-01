using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductSalesWebAPIAssignment.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? StaffId { get; set; }

    public int? CustomerId { get; set; }
    [JsonIgnore]
    public virtual Customer? Customer { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    [JsonIgnore]
    public virtual StaffProduct? Staff { get; set; }
}
