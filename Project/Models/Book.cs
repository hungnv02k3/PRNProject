using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Book
{
    public Guid BookId { get; set; }

    public string Title { get; set; } = null!;

    public Guid? AuthorId { get; set; }

    public Guid? PublisherId { get; set; }

    public Guid? GenreId { get; set; }

    public int? YearPublished { get; set; }

    public string? Isbn { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Publisher? Publisher { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
