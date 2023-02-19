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
    public class EditModel : PageModel
    {
        private readonly IVideoData _videoData; // inject the data service
        private readonly IHtmlHelper _helper;

        [BindProperty]
        public Video Video { get; set; } // add a private field containing the video that we want to edit
        public EditModel(IVideoData videoData, IHtmlHelper helper)
        {
            _videoData = videoData;
            _helper = helper;
        }

        public IEnumerable<SelectListItem> Genres { get; set; }

        // calls the data service and gets the video data for the supplied id. If an invalid id is passed, this is handled as a video error.
        public IActionResult OnGet(int? videoId)
        {
            Genres = _helper.GetEnumSelectList<MovieGenre>();
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
            if (ModelState.IsValid)
            {
                TempData["CommitMessage"] = Video.Id > 0 ? "Video Updated" : "Video Added";
                _ = Video.Id > 0 ? _videoData.UpdateVideo(Video) : _videoData.AddVideo(Video);
                _ = _videoData.Save();
                return RedirectToPage("./Detail", new { videoId = Video.Id });
            }
            Genres = _helper.GetEnumSelectList<MovieGenre>();
            return Page();
        }
    }
}