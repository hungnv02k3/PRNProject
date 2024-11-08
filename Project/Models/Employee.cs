using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Position { get; set; }

    public DateOnly HireDate { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
