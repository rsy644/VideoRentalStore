using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.Core;


namespace VideoRentalStore.Data
{
    public class VideoDbContext : DbContext
    {
        private DbContextOptions options;

        public VideoDbContext(DbContextOptions<VideoDbContext>
            dbContextOptns) : base(dbContextOptns)
        {

        }

        public VideoDbContext(DbContextOptions options)
        {
            this.options = options;
        }

        public DbSet<Video> Videos { get; set; }

    }
}
