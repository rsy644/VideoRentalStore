using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRentalStore.Data;

namespace VideoStore.ViewComponents
{
    public class VideoOfTheDayViewComponent : ViewComponent
    {
        private readonly IVideoData _videoData;

        public VideoOfTheDayViewComponent(IVideoData videoData)
        {
            _videoData = videoData;
        }

        public IViewComponentResult Invoke()
        {
            var video = _videoData.GetTopVideo();
            return View(video);
        }
    }
}
