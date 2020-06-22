using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.Models;
using CodingEvents.wwwroot;
using CodingEvents.wwwroot.Data;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        
       
        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.title = "Hello Moe";
            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/Events");
        }
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
        [HttpGet]
        [Route("/Events/Edit/{Id?}")]
        public IActionResult Edit(int Id)
        {
            ViewBag.eventToEdit = EventData.GetById(Id);
            
            return View();
        }
        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event retrievedEvent = EventData.GetById(eventId);
            retrievedEvent.Description = description;
            retrievedEvent.Name = name;
           
            return Redirect("/Events");
        }
    }
}
