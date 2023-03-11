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

        public IActionResult Index()
        {
            if (User.IsInRole("JobSeeker"))
            {
                return View("Index_Appl");
            }





            if (User.IsInRole("Employer"))
            {
                var user =  _userManager.GetUserAsync(User);
                List<Job> jobs = (List<Job>)_context.Jobs.Where(j => j.EmployerId == user.Id.ToString()).ToList();

                return View("Index_EMP", jobs);
            }
            return View();


            //return RedirectToAction("Index", "Jobs");
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