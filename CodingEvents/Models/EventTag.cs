using System;
using CodingEventsDemo.Models;

namespace CodingEvents.Models
{
    public class EventTag
    {
        public int EventId { get; set; }
        public Event Event { get; set; } //reference. Data is stored in other tables that's not EventTag

        public int TagId { get; set; }
        public Tag Tag { get; set; }//reference. Data is stored in other tables that's not EventTag. To it, it needs to be eagerly load, EventsController Detail method needs Include(et => et.Tag)



        public EventTag()
        {
        }
    }
}
