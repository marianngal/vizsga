using System;
using System.Collections.Generic;

namespace Company.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public string? PostalCode { get; set; }

    public string City { get; set; } = null!;

    public string? StateProvince { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
