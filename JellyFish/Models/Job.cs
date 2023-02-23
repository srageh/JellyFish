using System;
using System.Collections.Generic;

namespace JellyFish.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string Title { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Status { get; set; } = null!;

    public int CategoryId { get; set; }

    public int JobTypeId { get; set; }

    public string EmployerId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Applicant> Applicants { get; } = new List<Applicant>();

    public virtual Category Category { get; set; } = null!;

    public virtual Employer Employer { get; set; } = null!;

    public virtual ICollection<JobCategory> JobCategories { get; } = new List<JobCategory>();

    public virtual JobType JobType { get; set; } = null!;
}
