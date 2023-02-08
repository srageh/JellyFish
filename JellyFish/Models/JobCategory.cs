using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class JobCategory
    {
        public int JobCategoryId { get; set; }
        public int JobId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
