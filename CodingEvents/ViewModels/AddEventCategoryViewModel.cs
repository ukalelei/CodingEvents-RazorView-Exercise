using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "must be 3 to 20 characters long")]
        public string Name { get; set; }
    }
}
