using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using VideoRentalStore.Data;
using VideoRentalStore.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace VideoRentalStore.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterViewModel Register { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public RegisterModel(UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> SignInManager, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _userManager = UserManager;
            _signInManager = SignInManager;
        }

        public class InputModel
        {
            [Required]
            [StringLength(200)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [StringLength(200)]
            [Display(Name = "Username")]
            public string User { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = Input.Name,
                    UserName = Input.Name,
                    Email = Input.Email
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    TempData["Success"] = "User successfully registered!";

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return RedirectToPage("Index");
        }        
    }
}
