using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using VideoRentalStore.Core;
using VideoRentalStore.Data;

namespace VideoRentalStore.Pages.Videos
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IVideoData _videoData;

        public IEnumerable<Video> Videos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        public string PageTitle { get; set; }

        public ListModel(IConfiguration config, IVideoData videoData)
        {
            _config = config;
            _videoData = videoData;
        }
        public void OnGet(string searchQuery)
        {
            PageTitle = _config["VideoListPageTitle"];
            Videos = _videoData.ListVideos(searchQuery);
        }
    }
}