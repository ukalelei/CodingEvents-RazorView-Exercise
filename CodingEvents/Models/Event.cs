using System;
using CodingEvents.Models;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail{ get; set; }
        public string EventLocation { get; set; }
        public int NumberOfAttendees { get; set; }

        //Add an Enum Property to a Model Class
        //public EventType Type { get; set; } replacing this with new property to persist relationships between event and eventcategory objects
        public EventCategory Category { get; set; } //each event can only one eventCategory (1 to many)
        public int CategoryId { get; set; }//foreign key

        public int Id { get; set; }

        public Event()
        {
        }

        public Event(string name, string description, string contactEmail)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
        }


        public override string ToString()
        {
            return Name;

        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&

                Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
