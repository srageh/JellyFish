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
    public class Jobs1Controller : Controller
    {
        private readonly JellyFishDbContext _context;

        public Jobs1Controller(JellyFishDbContext context)
        {
            _context = context;
        }

        // GET: Jobs1
        public async Task<IActionResult> Index()
        {
            var jellyFishDbContext = _context.Jobs.Include(j => j.Category).Include(j => j.Employer).Include(j => j.JobType).Include(j => j.Level);
            return View(await jellyFishDbContext.ToListAsync());
        }

        // GET: Jobs1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Category)
                .Include(j => j.Employer)
                .Include(j => j.JobType)
                .Include(j => j.Level)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs1/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId");
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId");
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id");
            return View();
        }

        // POST: Jobs1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", job.CategoryId);
            ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId", job.JobTypeId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", job.LevelId);
            return View(job);
        }

        // GET: Jobs1/Edit/5
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", job.CategoryId);
            ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId", job.JobTypeId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", job.LevelId);
            return View(job);
        }

        // POST: Jobs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", job.CategoryId);
            ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId", job.JobTypeId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", job.LevelId);
            return View(job);
        }

        // GET: Jobs1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Category)
                .Include(j => j.Employer)
                .Include(j => j.JobType)
                .Include(j => j.Level)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs1/Delete/5
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
