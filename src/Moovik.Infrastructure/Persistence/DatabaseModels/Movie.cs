using System;
using System.Collections.Generic;

namespace Moovik.Infrastructure.Persistence.DatabaseModels;

public partial class Movie
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Imdb { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
