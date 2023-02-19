using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VideoRentalStore.Core;

namespace VideoRentalStore.Core
{
    public class Video : IValidatableObject
    {
        public int Id { get; set; }

        [Required, DisplayName("Video Title")]
        public string Title { get; set; }

        [Required, DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public MovieGenre Genre { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double Price { get; set; }

        [DisplayName("Lent Out")]
        public bool LentOut { get; set; }

        [DisplayName("Lent To")]
        public string LentTo { get; set; }

        public int Rating { get; set; }

        public string Review { get; set; }

        public string OnlineURL { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var property = new[] { nameof(LentTo) };
            var validationResults = new List<ValidationResult>();

            if (LentOut && string.IsNullOrEmpty(LentTo))
            {
                validationResults.Add(new ValidationResult("Please enter a name for Lent To", property));
            }

            return validationResults;
        }
    }
}
