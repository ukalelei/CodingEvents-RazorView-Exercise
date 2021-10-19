using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEvents.Models;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.ViewModels
{
    public class AddEventTagViewModel //allow the user to select the tag to add to the event with ID X
    {
        [Required(ErrorMessage = "Event is required")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Tag is required")]
        public int TagId { get; set; }

        public Event Event { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public AddEventTagViewModel(Event theEvent, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags) //loops thru collection of possible tags
            {
                Tags.Add(new SelectListItem //for each loop create corresponding selectlistitem that is used to render drop down option
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            Event = theEvent;
        }

        public AddEventTagViewModel()
        {
        }
    }
}
