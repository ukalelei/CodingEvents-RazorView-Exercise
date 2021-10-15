using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEvents.Mode;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Required(ErrorMessage = "Event location require")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage ="Number of attendees require")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Input can only contain characters 0-9")]
        [Range(0, 100000, ErrorMessage = "Cannot exeed 100000 attendees")]
        public string NumberOfAttendees { get; set; }

        [Required(ErrorMessage ="Category is required")]
        public int CategoryId { get; set; } //foreign key

        public List<SelectListItem> Categories { get; set; }

        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

        public AddEventViewModel() // adding no-arg constructor allows model binding
        {
        }








        /*// add an EventType property to our ViewModel to hold the event type that the user selects
        public EventType Type { get; set; }

        //list of all of the possible event types. Use for populating the select element
        //SelectListItem is an ASP.NET-provided class that represents each <option> element in a <select> element
        //This list only exists in AddEventViewModel cause we only need it for the purposes of displaying all of the options
        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            //populate property with default value since EventType options are not gonna change
            new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
            new SelectListItem(EventType.Meetup.ToString(),((int)EventType.Meetup).ToString()),
            new SelectListItem(EventType.Social.ToString(),((int)EventType.Social).ToString()),
            new SelectListItem(EventType.Workshop.ToString(),((int)EventType.Workshop).ToString()),
        };*/
    }
}
