using System.Collections.Generic;
using VideoRentalStore.Core;

namespace VideoRentalStore.Data
{
    public interface IVideoData
    {
        IEnumerable<Video> ListVideos(string title);

        Video GetVideo(int id);

        Video UpdateVideo(Video videoData);

        Video AddVideo(Video newVideo);

        Video DeleteVideo(Video video);

        int Save();
        Video GetTopVideo();
    }
}
