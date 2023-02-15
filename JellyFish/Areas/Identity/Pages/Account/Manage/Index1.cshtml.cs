using JellyFish.Areas.Identity.Data;
using JellyFish.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JellyFish.Areas.Identity.Pages.Account.Manage
{
    public class Index1Model : PageModel
    {
        private readonly UserManager<JellyFishUser> _userManager;
        private readonly SignInManager<JellyFishUser> _signInManager;
        private readonly JellyFish.Models.JellFishContext _context;


        public Index1Model(
            UserManager<JellyFishUser> userManager,
            SignInManager<JellyFishUser> signInManager,
            JellyFish.Models.JellFishContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
        }

        private async Task LoadAsync(JellyFishUser user)
        {
            var userMan = _userManager.GetUserId(HttpContext.User);



            var employerDetail = _context.Employers.Include(x=> x.EmployerNavigation).Include(x => x.Companies).Where(x => x.EmployerId == userMan).FirstOrDefault();




            var employeeCompany = _context.Companies.Include(x => x.Employer).Where(x => x.EmployerId == userMan).FirstOrDefault();

            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

       

            Username = userName;

            if(employerDetail != null)
            {
                Input = new InputModel
                {
                    PhoneNumber = employerDetail.EmployerNavigation.PhoneNumber,
                    FirstName = employerDetail.EmployerNavigation.FirstName,
                    LastName = employerDetail.EmployerNavigation.LastName,
                    Title = employerDetail.Title,
                    Name = employeeCompany.Name,
                    Url = employeeCompany.Url
                };
            }

            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
    
}

