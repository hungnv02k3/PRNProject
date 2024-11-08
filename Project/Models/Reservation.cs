using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Reservation
{
    public Guid ReservationId { get; set; }

    public Guid? BookId { get; set; }

    public Guid? MemberId { get; set; }

    public DateOnly ReservationDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Member? Member { get; set; }
}
