using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class Category
    {
        public Category()
        {
            JobCategories = new HashSet<JobCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<JobCategory> JobCategories { get; set; }
    }
}
