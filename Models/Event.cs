using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Id { get; }
        static private int nextId = 1;

        public string ContactEmail { get; set; }
        public string Location { get; set; }

        public int NumberAttendees { get; set; }
        public Event(string name, string description, string contactEmail, string location, int numberAttendees)
        {
            Name = name;
            Description = description;
            Id = nextId;
            nextId++;
            ContactEmail = contactEmail;
            Location = location;
            NumberAttendees = numberAttendees;
            
        }

        public Event()
        {
            Id = nextId;
           nextId++;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
