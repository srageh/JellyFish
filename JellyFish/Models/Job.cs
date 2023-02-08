using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class Job
    {
        public Job()
        {
            Applicants = new HashSet<Applicant>();
            JobCategories = new HashSet<JobCategory>();
        }

        public int JobId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int JobCategoryId { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }
        public virtual ICollection<JobCategory> JobCategories { get; set; }
    }
}
