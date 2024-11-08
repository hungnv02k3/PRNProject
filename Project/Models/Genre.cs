using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Genre
{
    public Guid GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
