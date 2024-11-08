using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Author
{
    public Guid AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
