using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Publisher
{
    public Guid PublisherId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
