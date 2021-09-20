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
    }
}
