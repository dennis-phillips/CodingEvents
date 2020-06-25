using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage ="Location is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage ="Location must be between 2 and 20 characters long")]
        public string Location { get; set; }

        [Required(ErrorMessage ="Number of attendees is required")]
        [Range(0,10000, ErrorMessage="Number must be between 0 and 10000")]
        public int NumberAttendees { get; set; }
    }
}
