using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Loan
{
    public Guid LoanId { get; set; }

    public Guid? BookId { get; set; }

    public Guid? MemberId { get; set; }

    public Guid? EmployeeId { get; set; }

    public DateOnly BorrowDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public DateOnly DueDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Member? Member { get; set; }
}
