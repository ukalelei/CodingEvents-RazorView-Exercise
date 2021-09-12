using System;
namespace CodingEvents.Models
{
    public class Event
    {
        public string Name{ get; set; }
        public string Description { get; set; }

        public int Id { get;}
        private static int nextId = 1; //static counter variable 

        //constructor
        public Event(string name, string description)
        {
            Name = name;
            Description = description;
            Id = nextId; // The only place id’s value may be assigned is in a constructor
            nextId++; //every time Event is created, it will increment nextId
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

        public override string ToString()
        {
            return Name;
        }
    }
}
