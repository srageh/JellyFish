using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JellyFish.Models;
using JellyFish.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using JellyFish.Models.View_Models;

namespace JellyFish.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly UserManager<JellyFishUser> _userManager;
		private readonly SignInManager<JellyFishUser> _signInManager;
		private readonly Models.JellyFishDbContext _context;
		private IWebHostEnvironment _webHostEnvironment;


		public HomeController(ILogger<HomeController> logger, JellyFishDbContext context, UserManager<JellyFishUser> userManager, SignInManager<JellyFishUser> signInManager, IWebHostEnvironment webHostEnvironment)
		{
            _logger = logger;
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			_webHostEnvironment = webHostEnvironment;

		}

        public async Task<IActionResult> IndexAsync(string? jobTitle)
        {
	



                //var userId = await _userManager.GetUserAsync(user);




            if (User.IsInRole("JobSeeker"))
            {

                var user = await _userManager.GetUserAsync(User);
                var applicantJobs = _context.Jobs.Include(x => x.Category).Include(x => x.JobType).Include(x => x.Level).Include(x => x.Employer.Company).ToList();


                if (!String.IsNullOrEmpty(jobTitle))
                {
                    applicantJobs = applicantJobs.Where(x => x.Title.Contains(jobTitle)).ToList();
                }


                var jobViewModel = GetViewModel(applicantJobs, null, null, null);
				
				return View("Index_Appl", jobViewModel);
				//return View( "Index_Appl");
			}


			if (User.IsInRole("Employer"))
			{
				return View("Index_Emp");
			}

			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult FilterJobType(JobViewModel types)
		{


			//var user =  _userManager.GetUserAsync(User);
			//var applicantJobs = _context.Jobs.Include(x => x.Category).Include(x => x.JobType).Include(x => x.Level).Include(x => x.Employer.Company).ToList();


			//var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "\\images\\", "amazon.png");



			List<int> allJobTypes = _context.Jobs.Select(x=> x.JobTypeId).Distinct().ToList();
			List<int> allCatTypes = _context.Jobs.Select(x => x.CategoryId).Distinct().ToList();
			List<int> allLevelTypes = _context.Jobs.Select(x => x.LevelId).Distinct().ToList();
			var jobFilter = types.JobTypeFilterId == null ? allJobTypes : new List<int>()
			{

				types.JobTypeFilterId ?? 0
			};

			var jobFilterCat = types.CategoryFilterId == null ? allCatTypes : new List<int>()
			{

				types.CategoryFilterId ?? 0
			};

			var jobFilterLev = types.LevelFilterId == null ? allLevelTypes : new List<int>()
			{

				types.LevelFilterId ?? 0
			};
			var jobFiltered = _context.Jobs.Include(x => x.Category).Include(x => x.JobType).Include(x => x.Level).Include(x => x.Employer.Company).Where(x=> jobFilter.Contains(x.JobTypeId) && jobFilterCat.Contains(x.CategoryId) && jobFilterLev.Contains(x.LevelId)).ToList();
			//test.ForEach(job => { job.Employer.Company.Logo = imagePath; });
			var jobViewModel = GetViewModel(jobFiltered, types.JobTypeFilterId, types.CategoryFilterId, types.LevelFilterId);
            

            return View("Index_Appl", jobViewModel);
		}


		public JobViewModel GetViewModel(List<Job> jobList, int? jobTypeFilter, int? categoryFilter, int? levelFilter)
		{
			//var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "\\images\\", "amazon.png");



			//List<int> /*allJobTypes*/ = _context.Jobs.Select(x => x.JobTypeId).Distinct().ToList();

			//jobList.ForEach(job => { job.Employer.Company.Logo = imagePath; });
			
			var s = new SelectList(_context.JobTypes.ToList(), "JobTypeId", "Name");
			ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
			ViewBag.Level = new SelectList(_context.Levels.ToList(), "Id", "Level1");
			ViewBag.Types = new SelectList(_context.JobTypes.ToList(), "JobTypeId", "Name");

			JobViewModel jobViewModel = new JobViewModel
			{

				Jobs = jobList,
				JobTypeFilterId = jobTypeFilter,
				CategoryFilterId = categoryFilter,
				LevelFilterId = levelFilter

			};


			return jobViewModel;
		}
    }
}