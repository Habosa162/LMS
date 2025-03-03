
    using LMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Areas.Identity.Pages.Account
{
    public class SelectRoleModell : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SelectRoleModell(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public string SelectedRole { get; set; }

        public async Task<IActionResult> OnPostAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Assign the selected role
            await _userManager.AddToRoleAsync(user, SelectedRole);

            // Sign in the user and redirect to the home page
            await _signInManager.SignInAsync(user, isPersistent: false);

            if (SelectedRole == "Student")
            {

                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
    }
}