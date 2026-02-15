using System;
using System.Collections.Generic;

namespace Company.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
