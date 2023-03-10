using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JellyFish.Models;
using JellyFish.Repository.IRepository;
using JellyFish.Models.View_Models;

namespace JellyFish.Controllers
{
    public class Jobs1Controller : Controller
    {
        //private readonly JellyFishDbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        //public Jobs1Controller(JellyFishDbContext context)
        //{
        //    _context = context;
        //}

        public Jobs1Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Jobs1
        public IActionResult Index()
        {
            IEnumerable<Job> jobPostingList = _unitOfWork.Job.GetAll();

            return View(jobPostingList);

            //var jellyFishDbContext = _context.Jobs.Include(j => j.Category).Include(j => j.Employer).Include(j => j.JobType).Include(j => j.Level);
            //return View(await jellyFishDbContext.ToListAsync());
        }

        // GET: Jobs1/Details/5
        //public IActionResult Details(int? id)
        //{
        //    if (id == null || _context.Jobs == null)
        //    {
        //        return NotFound();
        //    }

        //    var job = await _context.Jobs
        //        .Include(j => j.Category)
        //        .Include(j => j.Employer)
        //        .Include(j => j.JobType)
        //        .Include(j => j.Level)
        //        .FirstOrDefaultAsync(m => m.JobId == id);
        //    if (job == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(job);
        //}

        // GET: Jobs1/Create
        [HttpGet]
        public IActionResult Create()
        {
            JobPostingViewModel jobPostingViewModel= new()
            {
                job = new (),
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
            //var model = new Job();

            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.CategoryId.ToString()
            //    });
            //IEnumerable<SelectListItem> JobTypeLists = _unitOfWork.JobType.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.JobTypeId.ToString()
            //    });
            //IEnumerable<SelectListItem> LevelList = _unitOfWork.Level.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Level1,
            //        Value = u.Id.ToString()
            //    });           
            //ViewBag.CategoryList = CategoryList;
            //ViewBag.JobTypeList = JobTypeLists;
            //ViewBag.LevelList = LevelList;
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            //ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId");
            //ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "Name");
            //ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Level1");
            return View(jobPostingViewModel);
        }

        //public IActionResult Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)

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
                     Text = u.Level1,
                     Value = u.Id.ToString()
                 })
            };
            if (id == null || id == 0)
            {
                return View(jobPostingViewModel);
            }

            var jobFromDbFirst = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id);

            if (jobFromDbFirst == null)
            {
                return NotFound();
            }
            return View(jobFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Job obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Job.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "It's been updated successfully";
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

            return View(jobPostingViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var jobFromDbFirst = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id);
           
            if (jobFromDbFirst == null)
            {
                return NotFound();
            }
            return View(jobFromDbFirst);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Job.GetFirstOrDefault(u => u.JobId == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Job.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "It's been deleted successfully";
            return RedirectToAction("Index");
        }
        // POST: Jobs1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(job);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", job.CategoryId);
        //    ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //    ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "Name", job.JobTypeId);
        //    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Level1", job.LevelId);
        //    return View(job);
        //}

        // GET: Jobs1/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Jobs == null)
        //    {
        //        return NotFound();
        //    }

        //    var job = await _context.Jobs.FindAsync(id);
        //    if (job == null)
        //    {
        //        return NotFound();
        //    }
        //    //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", job.Category.Name);
        //    //ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //    //ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "Name", job.JobType.Name);
        //    //ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Level1", job.Level.Level1);

        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", job.CategoryId);
        //    ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //    ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId", job.JobTypeId);
        //    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", job.LevelId);
        //    return View(job);
        //}

        // POST: Jobs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        //{
        //    if (id != job.JobId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(job);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!JobExists(job.JobId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", job.CategoryId);
        //    ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //    ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId", job.JobTypeId);
        //    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", job.LevelId);
        //    return View(job);
        //}

        // GET: Jobs1/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Jobs == null)
        //    {
        //        return NotFound();
        //    }

        //    var job = await _context.Jobs
        //        .Include(j => j.Category)
        //        .Include(j => j.Employer)
        //        .Include(j => j.JobType)
        //        .Include(j => j.Level)
        //        .FirstOrDefaultAsync(m => m.JobId == id);
        //    if (job == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(job);
        //}

        //    // POST: Jobs1/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        if (_context.Jobs == null)
        //        {
        //            return Problem("Entity set 'JellyFishDbContext.Jobs'  is null.");
        //        }
        //        var job = await _context.Jobs.FindAsync(id);
        //        if (job != null)
        //        {
        //            _context.Jobs.Remove(job);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool JobExists(int id)
        //    {
        //        return (_context.Jobs?.Any(e => e.JobId == id)).GetValueOrDefault();
        //    }
        //}



        //    // GET: Jobs1
        //    public async Task<IActionResult> Index()
        //    {           

        //        var jellyFishDbContext = _context.Jobs.Include(j => j.Category).Include(j => j.Employer).Include(j => j.JobType).Include(j => j.Level);
        //        return View(await jellyFishDbContext.ToListAsync());
        //    }

        //    // GET: Jobs1/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null || _context.Jobs == null)
        //        {
        //            return NotFound();
        //        }

        //        var job = await _context.Jobs
        //            .Include(j => j.Category)
        //            .Include(j => j.Employer)
        //            .Include(j => j.JobType)
        //            .Include(j => j.Level)
        //            .FirstOrDefaultAsync(m => m.JobId == id);
        //        if (job == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(job);
        //    }

        //    // GET: Jobs1/Create
        //    public IActionResult Create()
        //    {
        //        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
        //        ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId");
        //        ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "Name");
        //        ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Level1");
        //        return View();
        //    }

        //    // POST: Jobs1/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    // public async Task<IActionResult> Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(job);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", job.CategoryId);
        //        ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //        ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "Name", job.JobTypeId);
        //        ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Level1", job.LevelId);
        //        return View(job);
        //    }

        //    // GET: Jobs1/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null || _context.Jobs == null)
        //        {
        //            return NotFound();
        //        }

        //        var job = await _context.Jobs.FindAsync(id);
        //        if (job == null)
        //        {
        //            return NotFound();
        //        }
        //        //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", job.Category.Name);
        //        //ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //        //ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "Name", job.JobType.Name);
        //        //ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Level1", job.Level.Level1);

        //        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", job.CategoryId);
        //        ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //        ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId", job.JobTypeId);
        //        ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", job.LevelId);
        //        return View(job);
        //    }

        //    // POST: Jobs1/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("JobId,Title,Salary,Status,CategoryId,JobTypeId,LevelId,EmployerId,Description")] Job job)
        //    {
        //        if (id != job.JobId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(job);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!JobExists(job.JobId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", job.CategoryId);
        //        ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId", job.EmployerId);
        //        ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "JobTypeId", "JobTypeId", job.JobTypeId);
        //        ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", job.LevelId);
        //        return View(job);
        //    }

        //    // GET: Jobs1/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null || _context.Jobs == null)
        //        {
        //            return NotFound();
        //        }

        //        var job = await _context.Jobs
        //            .Include(j => j.Category)
        //            .Include(j => j.Employer)
        //            .Include(j => j.JobType)
        //            .Include(j => j.Level)
        //            .FirstOrDefaultAsync(m => m.JobId == id);
        //        if (job == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(job);
        //    }

        //    // POST: Jobs1/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        if (_context.Jobs == null)
        //        {
        //            return Problem("Entity set 'JellyFishDbContext.Jobs'  is null.");
        //        }
        //        var job = await _context.Jobs.FindAsync(id);
        //        if (job != null)
        //        {
        //            _context.Jobs.Remove(job);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool JobExists(int id)
        //    {
        //      return (_context.Jobs?.Any(e => e.JobId == id)).GetValueOrDefault();
        //    }
    }
}
