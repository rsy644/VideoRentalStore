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
using AspNetCore.ReCaptcha;

namespace VideoRentalStore.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> SignInManager, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _userManager = UserManager;
            _signInManager = SignInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }

            [Required]
            public string Recaptcha { get; set; }
        }

        [ValidateReCaptcha]
        public async Task<IActionResult> OnPost(InputModel Input)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser signedUser = await _userManager.FindByEmailAsync(Input.Email);
                var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    TempData["Success"] = "User successfully logged in!";

                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            } else
            {
                return Page();
            }
        }
    }
}
