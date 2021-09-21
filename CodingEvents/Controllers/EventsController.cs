using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Models;
using CodingEvents.Data;
using CodingEvents.ViewModels;
using System.Numerics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        // GET: /<controller>/
        [HttpGet] //index only respond to get request
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll()); //store items in a list
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()//If the action attribute in the <form> tag leads to the same route as the form is being rendered at, you do not have to include an action attribute.
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel); //pass in new instance addEventViewModel created from above
        }

        //Route /Events/Add
        [HttpPost]
        //[Route("/Events/Add")] this not needed since the action method already matches the conventional routing of the application
        public IActionResult Add(AddEventViewModel addEventViewModel) //uses model binding to create new Event objects using request parameters
        {
            if (ModelState.IsValid) //ModelState.IsValid check if the constraints on the model properties are met
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    EventLocation = addEventViewModel.EventLocation,
                    NumberOfAttendees = Int32.Parse(addEventViewModel.NumberOfAttendees)

                };

                EventData.Add(newEvent); //Add() is called with newEvent and newEvent is saved
                return Redirect("/Events");
            }

            return View(addEventViewModel); //redirect user back to Add Event form if constraints are not met and view model object is not valid 
        }

        //action method to return a view designed to delete events.
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/Events/Delete/")]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events"); // return to homepage once Id is removed
        }


        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            
            ViewBag.title = "Edit Event NAME (id=ID)";
            return View();
        }

        [HttpPost]
        [Route("/events/edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            ViewBag.eventToEdit = EventData.GetById(eventId);
            ViewBag.newName = name;
            ViewBag.newDescription = description;

            return Redirect("/Events");
        }
         
    }
}
