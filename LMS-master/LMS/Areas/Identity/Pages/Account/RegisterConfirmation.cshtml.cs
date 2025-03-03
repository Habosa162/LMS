// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

//using System;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using LMS.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.WebUtilities;

//namespace LMS.Areas.Identity.Pages.Account
//{
//    [AllowAnonymous]
//    public class RegisterConfirmationModel : PageModel
//    {
//        private readonly UserManager<AppUser> _userManager;
//        private readonly IEmailSender _sender;

//        public RegisterConfirmationModel(UserManager<AppUser> userManager, IEmailSender sender)
//        {
//            _userManager = userManager;
//            _sender = sender;
//        }

//        /// <summary>
//        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public string Email { get; set; }



//        /// <summary>
//        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public bool DisplayConfirmAccountLink { get; set; }

//        /// <summary>
//        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public string EmailConfirmationUrl { get; set; }

//        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
//        {
//            if (email == null)
//            {
//                return RedirectToPage("/Index");
//            }
//            returnUrl = returnUrl ?? Url.Content("~/");

//            var user = await _userManager.FindByEmailAsync(email);
//            if (user == null)
//            {
//                return NotFound($"Unable to load user with email '{email}'.");
//            }

//            Email = email;
//            // Once you add a real email sender, you should remove this code that lets you confirm the account
//            DisplayConfirmAccountLink = true;
//            if (DisplayConfirmAccountLink)
//            {
//                user.EmailConfirmed = true;
//                var userId = await _userManager.GetUserIdAsync(user);
//                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
//                EmailConfirmationUrl = Url.Page(
//                    "/Home/Index",
//                    pageHandler: null,
//                    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
//                    protocol: Request.Scheme);
//            }

//            return Page();
//        }
//    }
//}

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using LMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _sender;

        public RegisterConfirmationModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender sender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sender = sender;
        }
        [BindProperty]
        public string Email { get; set; }
        public bool DisplayConfirmAccountLink { get; set; }
        public string EmailConfirmationUrl { get; set; }

        [BindProperty]
        public string SelectedRole { get; set; }  // Stores selected role from dropdown

        public List<SelectListItem> Roles { get; set; }  // List of roles for dropdown

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Index");  // Redirect to home if email is null
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;



            // Fetch available roles from Identity
            Roles = new List<SelectListItem>();
            foreach (var role in _roleManager.Roles)
            {
                Roles.Add(new SelectListItem { Value = role.Name, Text = role.Name });
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(SelectedRole))
            {
                ModelState.AddModelError(string.Empty, "Please select a role.");
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{Email}'.");
            }

            // Confirm email if not already confirmed
            if (!user.EmailConfirmed)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
            }

            // Assign selected role to user
            if (await _roleManager.RoleExistsAsync(SelectedRole))
            {
                await _userManager.AddToRoleAsync(user, SelectedRole);
            }

            return RedirectToPage("/Account/Login");
        }
    }
}
