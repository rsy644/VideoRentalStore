using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace VideoRentalStore.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } // Added this new column to the ApplicationUser model.

        public string User { get; set; }

        public override string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
