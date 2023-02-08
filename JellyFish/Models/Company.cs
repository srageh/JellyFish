using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string EmployerId { get; set; } = null!;
        public int? Name { get; set; }
        public int? Url { get; set; }

        public virtual Employer Employer { get; set; } = null!;
    }
}
