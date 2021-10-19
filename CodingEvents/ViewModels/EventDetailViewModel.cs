using System;
using System.Collections.Generic;
using CodingEvents.Models;
using CodingEventsDemo.Models;

namespace CodingEvents.ViewModels
{
    public class EventDetailViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }
        public string TagText { get; set; }  //build up the contents of TagText by looping over eventTags and appending tag names

        public EventDetailViewModel(Event theEvent, List<EventTag> eventTags)
        {
            EventId = theEvent.Id;
            Name = theEvent.Name;
            Description = theEvent.Description;
            ContactEmail = theEvent.ContactEmail;
            CategoryName = theEvent.Category.Name;

            TagText = "";
            for (var i = 0; i < eventTags.Count; i++)
            {
                TagText += ("#" + eventTags[i].Tag.Name); //makes tag look like: #csharp
                if (i < eventTags.Count - 1)
                {
                    TagText += ", "; //seperate tag with comma when displaye: "#java, #csharp, #object-oriented"
                }
            }
        }
    }
}
