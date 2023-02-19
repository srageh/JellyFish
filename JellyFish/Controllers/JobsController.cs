using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JellyFish.Models;

namespace JellyFish.Controllers
{
	public class JobsController : Controller
	{
		private readonly JellyFishDbContext _context;

		public JobsController(JellyFishDbContext context)
		{
			_context = context;
		}

		// GET: Jobs
		public async Task<IActionResult> Index(string? searchQuery)
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

			var job = await _context.Jobs
				.FirstOrDefaultAsync(m => m.JobId == id);
			if (job == null)
			{
				return NotFound();
			}

			return View(job);
		}

		// GET: Jobs/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Jobs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("JobId,Title,Description")] Job job)
		{
			if (ModelState.IsValid)
			{
				_context.Add(job);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(job);
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
	}
}
