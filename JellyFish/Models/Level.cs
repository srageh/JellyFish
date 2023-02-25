using System;
using System.Collections.Generic;

namespace JellyFish.Models;

public partial class Level
{
    public int Id { get; set; }

    public string? Level1 { get; set; }

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();
}
