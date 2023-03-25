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
using System.Collections;

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


				if (!String.IsNullOrEmpty(searchQuery))
				{
					if (searchQuery.Equals("inact"))
					{
						var jobsx = _context.Jobs.Where(r => r.IsActive == false).Include(x => x.Category);

						// For counting applicants' number on job posting for employer

						try
						{
							var jobList = _context.Jobs.Where(r => r.IsActive == false).Select(x => x.JobId).ToList();
							var applicantList = _context.Applicants.Select(x => x.JobId).ToList();
							List<string> applicantCountArray = new List<string>();
							int count = 0;


							for (int i = 0; i < jobList.Count; i++)
							{
								for (int j = 0; j < applicantList.Count; j++)
								{
									if (applicantList[j] == jobList[i])
									{
										count++;
									}
								}

								applicantCountArray.Add(jobList[i] + " " + count);
								count = 0;
							}

							if (applicantCountArray.Count > 0)
							{

								ViewBag.ApplicantCountArray = applicantCountArray;
							}
							//else
							//{
							//    ViewBag.ApplicantCountArray = 0;
							//}




							return View("Index_Emp", jobsx.ToList());



						}
						catch (Exception ex)
						{
							//Response.Write("Property: " + ex.Message);
							return View();
						}

					}

					if (searchQuery.Equals("act"))
					{
						var jobsz = _context.Jobs.Where(r => r.IsActive == true).Include(x => x.Category);

						// For counting applicants' number on job posting for employer

						try
						{
							var jobList = _context.Jobs.Where(r => r.IsActive == true).Select(x => x.JobId).ToList();
							var applicantList = _context.Applicants.Select(x => x.JobId).ToList();
							List<string> applicantCountArray = new List<string>();
							int count = 0;




							for (int i = 0; i < jobList.Count; i++)
							{
								for (int j = 0; j < applicantList.Count; j++)
								{
									if (applicantList[j] == jobList[i])
									{
										count++;
									}
								}



								applicantCountArray.Add(jobList[i] + " " + count);
								count = 0;
							}
							if (applicantCountArray.Count > 0)
							{

								ViewBag.ApplicantCountArray = applicantCountArray;
							}
							else
							{
								ViewBag.ApplicantCountArray = applicantCountArray;
							}




							return View("Index_Emp", jobsz.ToList());



						}
						catch (Exception ex)
						{
							//Response.Write("Property: " + ex.Message);
							return View();
						}

					}


					if (searchQuery.Equals("all"))
					{

						var jobsv = _context.Jobs.Include(x => x.Category);

						// For counting applicants' number on job posting for employer
						using (JellyFishDbContext context = new JellyFishDbContext())
						{
							try
							{
								Job job = new Job();
								var jobList = _context.Jobs.Select(x => x.JobId).ToList();
								var applicantList = _context.Applicants.Select(x => x.JobId).ToList();
								List<string> applicantCountArray = new List<string>();
								int count = 0;




								for (int i = 0; i < jobList.Count; i++)
								{
									for (int j = 0; j < applicantList.Count; j++)
									{
										if (applicantList[j] == jobList[i])
										{
											count++;
										}
									}



									applicantCountArray.Add(jobList[i] + " " + count);
									count = 0;
								}
								if (applicantCountArray.Count > 0)
								{

									ViewBag.ApplicantCountArray = applicantCountArray;
								}
								//else
								//{
								//    ViewBag.ApplicantCountArray = 0;
								//}




								return View("Index_Emp", jobsv.ToList());



							}
							catch (Exception ex)
							{
								//Response.Write("Property: " + ex.Message);
								return View();
							}
						}
					}
				}


				var jobs = _context.Jobs.Include(x => x.Category);

				// For counting applicants' number on job posting for employer
				using (JellyFishDbContext context = new JellyFishDbContext())
				{
					try
					{
						Job job = new Job();
						var jobList = _context.Jobs.Select(x => x.JobId).ToList();
						var applicantList = _context.Applicants.Select(x => x.JobId).ToList();
						List<string> applicantCountArray = new List<string>();
						int count = 0;




						for (int i = 0; i < jobList.Count; i++)
						{
							for (int j = 0; j < applicantList.Count; j++)
							{
								if (applicantList[j] == jobList[i])
								{
									count++;
								}
							}



							applicantCountArray.Add(jobList[i] + " " + count);
							count = 0;
						}
						if (applicantCountArray.Count > 0)
						{

							ViewBag.ApplicantCountArray = applicantCountArray;
						}
						//else
						//{
						//    ViewBag.ApplicantCountArray = 0;
						//}




						return View("Index_Emp", jobs.ToList());



					}
					catch (Exception ex)
					{
						//Response.Write("Property: " + ex.Message);
						return View();
					}
				}

			}
			return View();
		}


		public async Task<IActionResult> DisplayApplicents(string? searchQuery)
		{
			var user = _userManager.GetUserId(User);
			List<Job> jobs = (List<Job>)_context.Jobs.Include(k => k.Level).Include(k => k.Category).Include(k => k.JobType).Include(l => l.Employer).ThenInclude(q => q.Company).Include(w => w.Applicants).ThenInclude(r => r.User).Where(j => j.EmployerId == user.ToString()).ToList();

			return View("DisplayAppl", jobs);	
		}






		public async Task<IActionResult> RadioSelect(string? searchQuery)
		{

			if (searchQuery.Equals("all"))
			{
				return RedirectToAction("Index", "Jobs", new { searchQuery = "all" });
			}


			if (searchQuery.Equals("act"))
			{

				return RedirectToAction("Index", "Jobs", new { searchQuery = "act" });
			}


			if (searchQuery.Equals("inact"))
			{

				return RedirectToAction("Index", "Jobs", new { searchQuery = "inact" });
			}
			return View();
		}










		// GET: Jobs/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Jobs == null)
			{
				return NotFound();
			}

			var job = await _context.Jobs.Include(j => j.Applicants).Include(x => x.Employer.Company).Include(x => x.JobType).Include(x => x.Level).Include(x => x.Category).FirstOrDefaultAsync(m => m.JobId == id);
			if (job == null)
			{
				return NotFound();
			}

			ViewData["already"] = false;
			if (job.Applicants.Count != 0)
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
					Text = u.LevelName,
					Value = u.Id.ToString()
				})

			};

			return View(jobPostingViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Title,Salary,isActive, isOpen, CategoryId,JobTypeId,LevelId,EmployerId,Description, Location")] Job job)
		{
			if (ModelState.IsValid)
			{
				job.CreatedDate = DateTime.Today.Date;
				job.IsActive = false;
				job.IsOpen = false;
				_unitOfWork.Job.Add(job);
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}

			JobPostingViewModel jobPostingViewModel = new()
			{
				job = job,
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
					 Text = u.LevelName,
					 Value = u.Id.ToString()
				 })
			};
			//return RedirectToAction("Index");
			return View(jobPostingViewModel);
		}



		public IActionResult Edit(int? id)
		{
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
					 Text = u.LevelName,
					 Value = u.Id.ToString()
				 })
			};
			if (id == null || id == 0)
			{
				return View(jobPostingViewModel);
			}
			else
			{
				jobPostingViewModel.job = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id);
				return View(jobPostingViewModel);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
		{
			if (ModelState.IsValid)
			{
				if (job.JobId == 0)
				{
					_unitOfWork.Job.Add(job);
				}
				else
				{
					_unitOfWork.Job.Update(job);
				}

				_unitOfWork.Save();
				//TempData["success"] = "It's been updated successfully";
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
					 Text = u.LevelName,
					 Value = u.Id.ToString()
				 })
			};

			return View(jobPostingViewModel);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var jobFromDbFirst = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id);
			int categoryId = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id).CategoryId;
			int jobTypeId = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id).JobTypeId;
			int levelId = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id).LevelId;

			JobPostingViewModel jobPostingViewModel = new()
			{
				job = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id),
				category = _unitOfWork.Category.GetFirstOrDefault(u => u.CategoryId == categoryId),
				jobType = _unitOfWork.JobType.GetFirstOrDefault(u => u.JobTypeId == jobTypeId),
				level = _unitOfWork.Level.GetFirstOrDefault(u => u.Id == levelId)

			};

			if (jobFromDbFirst == null)
			{
				return NotFound();
			}
			return View(jobPostingViewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id);
			if (obj == null)
			{
				return NotFound();
			}

			_unitOfWork.Job.Remove(obj);
			_unitOfWork.Save();
			//TempData["success"] = "It's been deleted successfully";
			return RedirectToAction("Index");
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
			ViewBag.Level = new SelectList(_context.Levels.ToList(), "Id", "LevelName");
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
