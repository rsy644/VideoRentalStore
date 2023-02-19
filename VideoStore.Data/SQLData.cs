using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VideoRentalStore.Data
{
    public class SQLData : IVideoData
    {
        private readonly VideoDbContext _database; // brings in VideoDbContext via 
        // the class constructor and saves it to a private FieldAccessException called _database.

        public SQLData(VideoDbContext database) => _database = database;
        public Video AddVideo(Video newVideo)
        {
            _ = _database.Add(newVideo);
            return newVideo;
        }

        public Video GetVideo(int id) => _database.Videos.Find(id);

        public IEnumerable<Video> ListVideos(string title) => _database.Videos
            .Where(x => string.IsNullOrEmpty(title)
            || x.Title.StartsWith(title))
            .OrderBy(x => x.Title);

        public int Save() => _database.SaveChanges();

        public Video UpdateVideo(Video videoData)
        {
            var entity = _database.Videos.Attach(videoData); // finds and updates videos
            entity.State = EntityState.Modified; // tells entity framework that something on the Video entity has changed.
            return videoData;
        }

        public Video DeleteVideo(Video video)
        {
            var entity = _database.Videos.FirstOrDefault(x => x.Id == video.Id);

            if (video != null)
            {
                _database.Videos.Remove(entity);
            }

            return video;
        }

        public Video GetTopVideo()
        {
            var rnd = new Random();
            if (_database.Videos.Count() == 0)
                return new Video();
            else
            {
                var r = rnd.Next(1, _database.Videos.Count());
                return _database.Videos.Find(r);
            }
        }

    }
}
