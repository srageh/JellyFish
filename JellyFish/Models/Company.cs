using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string EmployerId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Url { get; set; }

        public virtual Employer Employer { get; set; } = null!;
    }
}
