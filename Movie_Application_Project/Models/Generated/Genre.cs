using System;
using System.Collections.Generic;

namespace PROG2500_AF_IMDB_Project.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Title> Titles { get; } = new List<Title>();
}
