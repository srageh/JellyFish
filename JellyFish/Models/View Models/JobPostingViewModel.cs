using Microsoft.AspNetCore.Mvc.Rendering;

namespace JellyFish.Models.View_Models
{
    public class JobPostingViewModel
    {
           public int JobId { get; set; }

    public string Title { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Status { get; set; } = null!;

    public int CategoryId { get; set; }

    public int JobTypeId { get; set; }

    public int LevelId { get; set; }

    public string EmployerId { get; set; } = null!;

    public string Description { get; set; } = null!;
    }
}
