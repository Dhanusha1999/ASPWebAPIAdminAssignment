using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductSalesWebAPIAssignment.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? StoreName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }
    [JsonIgnore]
    public virtual ICollection<StaffProduct> StaffProducts { get; set; } = new List<StaffProduct>();
}
