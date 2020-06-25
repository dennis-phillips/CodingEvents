using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.Models;
using CodingEvents.wwwroot;
using CodingEvents.wwwroot.Data;
using CodingEvents.ViewModels;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        
       
        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.title = "Hello Moe";
            List<Event> events = new List<Event>(EventData.GetAll());
            return View(events);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]

        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Location = addEventViewModel.Location,
                    NumberAttendees =addEventViewModel.NumberAttendees

                };
                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);
           
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
