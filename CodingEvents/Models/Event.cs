﻿using System;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public int Id { get; }
        static private int nextId = 1;

        public Event()
        {
            Id = nextId; // The only place id’s value may be assigned is in a constructor
            nextId++; //every time Event is created, it will increment nextId
        }


        public Event(string name, string description): this() //constructor chaining
        {
            Name = name;
            Description = description;
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
