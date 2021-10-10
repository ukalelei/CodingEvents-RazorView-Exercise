using System;
namespace CodingEvents.Models
{
    //represents data that will be stored in our database
    public class EventCategory
    {
        public int Id { get; set; } //Primary key properties must have both a getter and setter
        public string Name { get; set; }

        public EventCategory() //no agument constructor
        {
        }

        public EventCategory(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;

        }

        public override bool Equals(object obj)
        {
            return obj is EventCategory @eventCategory &&

                Id == @eventCategory.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
