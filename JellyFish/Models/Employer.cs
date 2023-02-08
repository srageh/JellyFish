using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class Employer
    {
        public Employer()
        {
            Companies = new HashSet<Company>();
        }

        public string EmployerId { get; set; } = null!;
        public string Title { get; set; } = null!;

        public virtual AspNetUser EmployerNavigation { get; set; } = null!;
        public virtual ICollection<Company> Companies { get; set; }
    }
}
