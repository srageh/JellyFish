using Microsoft.AspNetCore.Mvc.Rendering;

namespace JellyFish.Models.View_Models
{
    public class JobPostingViewModel
    {
        public Job job { get; set; }
        
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> JobTypeList { get; set; }   
        public IEnumerable<SelectListItem> LevelList { get; set; }
    }
}
