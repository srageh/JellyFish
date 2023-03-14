using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JellyFish.Models;
using JellyFish.Models.View_Models;
using Microsoft.AspNetCore.Identity;
using JellyFish.Areas.Identity.Data;
using JellyFish.Repository;
using JellyFish.Repository.IRepository;
using System.Security.Claims;



namespace JellyFish.Controllers
{
	public class JobsController : Controller
	{
		private readonly JellyFishDbContext _context;
        private readonly UserManager<JellyFishUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(JellyFishDbContext context, UserManager<JellyFishUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _context = context;
            _unitOfWork = unitOfWork;   
        }

        // GET: Jobs
        public async Task<IActionResult> Index(string? searchQuery)
		{
			ViewData["searchQuery"] = searchQuery;

  


            if (User.IsInRole("JobSeeker"))
            {

                var user = await _userManager.GetUserAsync(User);
                var applicantJobs = _context.Jobs.Include(x => x.Category).Include(x => x.JobType).Include(x => x.Level).Include(x => x.Employer.Company).ToList();


                if (!String.IsNullOrEmpty(searchQuery))
                {
                    applicantJobs = applicantJobs.Where(x => x.Title.Contains(searchQuery)).ToList();
                }


                var jobViewModel = GetViewModel(applicantJobs, null, null, null);

                return View("Index_Appl", jobViewModel);
                //return View( "Index_Appl");
            }



            //return View("Index_Appl", await jobs.ToListAsync());

            
			if (User.IsInRole("Employer"))
			{
				var jobs = from g in _context.Jobs.					 
					 Include(g => g.Category)
						   select g;

				return View("Index_Emp", await jobs.ToListAsync());

			}




			return View();

            //return _context.Jobs != null ?
            //			  View(await _context.Jobs.ToListAsync()) :
            //			  Problem("Entity set 'JellyFishDbContext.Jobs'  is null.");
        }

		// GET: Jobs/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Jobs == null)
			{
				return NotFound();
			}

			var job = await _context.Jobs.Include(j => j.Applicants).Include(x=>x.Employer.Company).Include(x=> x.JobType).Include(x=> x.Level).Include(x=> x.Category).FirstOrDefaultAsync(m => m.JobId == id);
			if (job == null)
			{
				return NotFound();
			}

			ViewData["already"] = false;
			if(job.Applicants.Count != 0)
			{
                ViewData["already"] = true;
            }


			return View(job);
		}

    
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
        //    //ViewData["EmployerId"] = new SelectList(_unitOfWork.Em, "EmployerId", "EmployerId");
        //    ViewBag.JobTypeId = new SelectList(_context.JobTypes.ToList(), "JobTypeId", "Name");
        //    ViewBag.LevelId = new SelectList(_context.Levels.ToList(), "Id", "Level1");
        //    ViewBag.EmployeeId = _userManager.GetUserId(User);
        //    return View();
        //}

        ////public IActionResult Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        //{
        //    job.EmployerId = _userManager.GetUserId(User).ToString();
        //    ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
        //    //ViewData["EmployerId"] = new SelectList(_unitOfWork.Em, "EmployerId", "EmployerId");
        //    ViewBag.JobTypeId = new SelectList(_context.JobTypes.ToList(), "JobTypeId", "Name");
        //    ViewBag.LevelId = new SelectList(_context.Levels.ToList(), "Id", "Level1");
        //    ViewBag.EmployeeId = _userManager.GetUserId(User);

        //    if (ModelState.IsValid)
        //    {
        //        _context.Jobs.Add(job);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
           
        //    return View(job);

       
        //}





        // GET: Jobs1/Create
        [HttpGet]
        public IActionResult Create()
        {

            var employerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TempData["employerId"] = employerId;
            ViewBag.EmployerId = TempData["employerId"];


            JobPostingViewModel jobPostingViewModel = new()
            {
                job = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                JobTypeList = _unitOfWork.JobType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.JobTypeId.ToString()
                }),
                LevelList = _unitOfWork.Level.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Level1,
                    Value = u.Id.ToString()
                })

            };

            return View(jobPostingViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Job.Add(job);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            JobPostingViewModel jobPostingViewModel = new()
            {
                job = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                 u => new SelectListItem
                 {
                     Text = u.Name,
                     Value = u.CategoryId.ToString()
                 }),
                JobTypeList = _unitOfWork.JobType.GetAll().Select(
                 u => new SelectListItem
                 {
                     Text = u.Name,
                     Value = u.JobTypeId.ToString()
                 }),
                LevelList = _unitOfWork.Level.GetAll().Select(
                 u => new SelectListItem
                 {
                     Text = u.Level1,
                     Value = u.Id.ToString()
                 })
            };
            //return RedirectToAction("Index");
            return View(jobPostingViewModel);
        }








        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Jobs == null)
			{
				return NotFound();
			}

			var job = await _context.Jobs.FindAsync(id);
			if (job == null)
			{
				return NotFound();
			}
			return View(job);
		}

		// POST: Jobs/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("JobId,Title,Description")] Job job)
		{
			if (id != job.JobId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(job);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!JobExists(job.JobId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(job);
		}

		// GET: Jobs/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Jobs == null)
			{
				return NotFound();
			}

			var job = await _context.Jobs
				.FirstOrDefaultAsync(m => m.JobId == id);
			if (job == null)
			{
				return NotFound();
			}

			return View(job);
		}

		// POST: Jobs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Jobs == null)
			{
				return Problem("Entity set 'JellyFishDbContext.Jobs'  is null.");
			}
			var job = await _context.Jobs.FindAsync(id);
			if (job != null)
			{
				_context.Jobs.Remove(job);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool JobExists(int id)
		{
			return (_context.Jobs?.Any(e => e.JobId == id)).GetValueOrDefault();
		}

        [HttpPost]
        public IActionResult FilterJobType(JobViewModel types)
        {


            //var user =  _userManager.GetUserAsync(User);
            //var applicantJobs = _context.Jobs.Include(x => x.Category).Include(x => x.JobType).Include(x => x.Level).Include(x => x.Employer.Company).ToList();


            //var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "\\images\\", "amazon.png");



            List<int> allJobTypes = _context.Jobs.Select(x => x.JobTypeId).Distinct().ToList();
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
            var jobFiltered = _context.Jobs.Include(x => x.Category).Include(x => x.JobType).Include(x => x.Level).Include(x => x.Employer.Company).Where(x => jobFilter.Contains(x.JobTypeId) && jobFilterCat.Contains(x.CategoryId) && jobFilterLev.Contains(x.LevelId)).ToList();
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
