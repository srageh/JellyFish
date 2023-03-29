using System;
using System.Collections.Generic;

namespace JellyFish.Models;

public partial class Applicant
{
    public int ApplicantId { get; set; }

    public int JobId { get; set; }

    public string UserId { get; set; } = null!;

    public bool? IsAccepted { get; set; }

    public string? IsApplied { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
