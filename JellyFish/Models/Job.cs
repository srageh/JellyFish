using System;
using System.Collections.Generic;

namespace JellyFish.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Applicant> Applicants { get; } = new List<Applicant>();

    public virtual ICollection<JobCategory> JobCategories { get; } = new List<JobCategory>();
}
