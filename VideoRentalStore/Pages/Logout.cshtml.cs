using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System.Threading.Tasks;
using VideoRentalStore.Data;

namespace VideoRentalStore.Pages
{
    public class LogoutModel : PageModel {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;

        public LogoutModel(SignInManager<ApplicationUser> SignInManager, ILogger<IndexModel> logger)
        {
            _signInManager = SignInManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                //return Page();
                return RedirectToPage();
            }
        }
    }
}
