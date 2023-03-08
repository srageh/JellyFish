using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JellyFish.Models;
using Microsoft.AspNetCore.Identity;
using JellyFish.Areas.Identity.Data;

namespace JellyFish.Areas.Identity.Pages.Account.Manage
{
    public class MyJobsModel : PageModel
    {
        private readonly JellyFish.Models.JellyFishDbContext _context;
        private readonly UserManager<JellyFishUser> _userManager;

        public MyJobsModel(JellyFish.Models.JellyFishDbContext context, UserManager<JellyFishUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Applicant> Applicant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Applicants != null)
            {
                Applicant = _context.Applicants.Include(x => x.Job).ToList();
            }
        }
    }
}
