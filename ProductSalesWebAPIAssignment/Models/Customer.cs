using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductSalesWebAPIAssignment.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
