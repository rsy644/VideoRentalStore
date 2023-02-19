using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoRentalStore.Core;
using VideoRentalStore.Data;

namespace VideoRentalStore.Pages.Videos
{
    public class DetailModel : PageModel
    {
        private readonly IVideoData _videoData;
        public Video Video { get; set; }

        [TempData]
        public string CommitMessage { get; set; }

        public DetailModel(IVideoData videoData)
        {
            _videoData = videoData;
        }
        public IActionResult OnGet(int videoId)
        {
            Video = _videoData.GetVideo(videoId);

            return Video == null ? RedirectToPage("./VideoError", new
            { message = "The video does not exist" }) : (IActionResult)
            Page();
        }
    }
}