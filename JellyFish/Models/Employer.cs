using System;
using System.Collections.Generic;

namespace JellyFish.Models;

public partial class Employer
{
    public string EmployerId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; } = new List<Company>();

    public virtual AspNetUser EmployerNavigation { get; set; } = null!;
}
