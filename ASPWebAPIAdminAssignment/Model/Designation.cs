using System;
using System.Collections.Generic;

namespace ASPWebAPIAdminAssignment.Model;

public partial class Designation
{
    public int DesignationId { get; set; }

    public string? DesignationName { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
