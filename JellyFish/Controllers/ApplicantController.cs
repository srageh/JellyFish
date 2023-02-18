using JellyFish.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JellyFish.Controllers
{
	public class ApplicantController : Controller
    {

        private readonly JellyFishDbContext _context;

        public ApplicantController(JellyFishDbContext context)
        {
            _context = context;
        }


        // GET: ApplicantController
        public async Task<ActionResult> IndexAsync(string searchQuery)
        {
            ViewData["searchQuery"] = searchQuery;

            var jobs = from g in _context.Jobs.
                        Include(d => d.JobCategories).
                        ThenInclude(g => g.Category)
						select g;


            if (!string.IsNullOrEmpty(searchQuery))
            {
				jobs = jobs.Where(g => g.Title.Contains(searchQuery));
				/*||
					g.Developer.Name.Contains(searchQuery) ||
					g.Publisher.Name.Contains(searchQuery) ||
					g.Genre.Type.Contains(searchQuery));*/
				
            }

            return View(await jobs.ToListAsync());
        }

		// GET: ApplicantController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ApplicantController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ApplicantController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(IndexAsync));
			}
			catch
			{
				return View();
			}
		}

		// GET: ApplicantController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ApplicantController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(IndexAsync));
			}
			catch
			{
				return View();
			}
		}

		// GET: ApplicantController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ApplicantController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(IndexAsync));
			}
			catch
			{
				return View();
			}
		}
	}
}
