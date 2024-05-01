using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductSalesWebAPIAssignment.Models;

public partial class StaffProduct
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Active { get; set; }

    public int? StoreId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    [JsonIgnore]

    public virtual Store? Store { get; set; }
}
