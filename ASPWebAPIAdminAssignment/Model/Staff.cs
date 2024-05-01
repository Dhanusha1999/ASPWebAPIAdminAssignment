using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ASPWebAPIAdminAssignment.Model;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int? DesignationId { get; set; }
    [JsonIgnore]

    public virtual Designation? Designation { get; set; }
}
