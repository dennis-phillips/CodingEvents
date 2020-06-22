using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CodingEvents.wwwroot.Data;
using CodingEvents.Models;

namespace CodingEvents.wwwroot.Data
{
    public class EventData
    {
        static private Dictionary<int, Event> Events = new Dictionary<int, Event>();

        // GetAll
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        // Add
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        // Remove
        public static void Remove(int id)
        {
            Events.Remove(id);
        }

        // GetById
        public static Event GetById(int id)
        {
            return Events[id];
        }

    }

}
