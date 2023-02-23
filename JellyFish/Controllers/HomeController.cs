using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JellyFish.Models;
using JellyFish.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JellyFish.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly UserManager<JellyFishUser> _userManager;
		private readonly SignInManager<JellyFishUser> _signInManager;
		private readonly Models.JellyFishDbContext _context;


		public HomeController(ILogger<HomeController> logger, JellyFishDbContext context, UserManager<JellyFishUser> userManager, SignInManager<JellyFishUser> signInManager)
		{
            _logger = logger;
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;

		}

        public async Task<IActionResult> IndexAsync()
        {


			var user = await _userManager.GetUserAsync(User);
			var jobs = _context.Jobs.Include(x=> x.Category).Include(x=> x.JobType).Include(x=> x.Employer.Company).ToList();


			//var userId = await _userManager.GetUserAsync(user);




			if (User.IsInRole("JobSeeker"))
            {
				return View("Index_Appl", jobs);
				
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
    }
}