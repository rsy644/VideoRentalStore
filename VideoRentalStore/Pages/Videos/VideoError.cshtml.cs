using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VideoRentalStore.Core;

namespace VideoRentalStore.Pages.Videos
{
    public class VideoErrorModel : PageModel
    {
        private readonly ILogger<VideoErrorModel> _logger;
        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }

        public VideoErrorModel(ILogger<VideoErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int videoId)
        {
            _logger.LogError(Message);
        }
    }
}
