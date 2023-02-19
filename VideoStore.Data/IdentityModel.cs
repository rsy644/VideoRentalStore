using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VideoRentalStore.Data
{
    public class IdentityModel : VideoDbContext
    {
        public IdentityModel(DbContextOptions options): base(options)
        {

        }
        public DbSet<VideoDbContext> login { get; set; }
    }
}
