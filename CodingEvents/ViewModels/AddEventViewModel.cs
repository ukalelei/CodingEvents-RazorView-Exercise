using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        //add validation attribute
        [Required(ErrorMessage = "Name is required")] //user must include if not error message
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 to 50 characters")] //require length of string field
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description of event")]
        [StringLength(500, ErrorMessage = "Description needs to be less than 500 characters")] //require length of string field 
        public string Description { get; set; }

        [EmailAddress] //make sure user enter email
        public string ContactEmail { get; set; }

        //cannot be null or blank
        [Required(ErrorMessage = "Event location require")]
        public string EventLocation { get; set; }

        //valid num 0-100000
        [Required(ErrorMessage ="Number of attendees require")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Input can only contain characters 0-9")]
        [Range(0, 100000, ErrorMessage = "Cannot exeed 100000 attendees")]
        public string NumberOfAttendees { get; set; }

        
    }
}
