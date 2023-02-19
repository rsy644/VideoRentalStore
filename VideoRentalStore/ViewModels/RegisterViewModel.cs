using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRentalStore.Data;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalStore.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }
    }
}
