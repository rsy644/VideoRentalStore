using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoRentalStore.Core;
using VideoRentalStore.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace VideoRentalStore.Pages.Videos
{
    public class DeleteModel : PageModel
    {
        private readonly IVideoData _videoData; // inject the data service
        private readonly IHtmlHelper _helper;

        [BindProperty]
        public Video Video { get; set; } // add a private field containing the video that we want to delete
        public DeleteModel(IVideoData videoData, IHtmlHelper helper)
        {
            _videoData = videoData;
            _helper = helper;
        }

        public IActionResult OnGet(int? videoId)
        {
            Video = videoId.HasValue ? _videoData.GetVideo(videoId.Value)
                : new Video
                {
                    ReleaseDate = DateTime.Now.Date
                };

            return Video == null ? RedirectToPage("./VideoError", new
            {
                message = "The video does not exist"
            }) : (IActionResult)
            Page();
        }

        public IActionResult OnPost()
        {
            TempData["CommitMessage"] = "Video Deleted";
            _ = _videoData.DeleteVideo(Video);
            _ = _videoData.Save();
            return RedirectToPage("./List", new { videoId = Video.Id });
        }


    }
}