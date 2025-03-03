using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LMS.Areas.Identity.Pages.Account
{
    public class SelectRoleModel : PageModel
    {
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _Signinmanager { get; }

        public SelectRoleModel(UserManager<AppUser> usermanager , SignInManager<AppUser> signinmanager)
        {
            _userManager = usermanager;
            _Signinmanager = signinmanager;
        }
        //[BindProperty]
        //public string SelectedRole { get; set; }
     
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SetRole(string role)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, role);
                return RedirectToAction("Index", "Home"); // Redirect to homepage
            }
            return RedirectToAction("SelectRole");
        }
    }
}
