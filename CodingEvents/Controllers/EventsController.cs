﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Models;
using CodingEvents.Data;
using CodingEvents.ViewModels;
using System.Numerics;
using CodingEvents.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext context;
        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet] //index only respond to get request
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(Event.GetAll()); //store items in a list
            List<Event> events = context.Events.ToList(); //store items in a list
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
                EventCategory category = context.Categories.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    EventLocation = addEventViewModel.EventLocation,
                    NumberOfAttendees = Int32.Parse(addEventViewModel.NumberOfAttendees),
                    Category = category
                };

                //EventData.Add(newEvent); //Add() is called with newEvent and newEvent is saved
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/Events");
            }

            return View(addEventViewModel); //redirect user back to Add Event form if constraints are not met and view model object is not valid 
        }

        //action method to return a view designed to delete events.
        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = context.Events.ToList();
            return View();
        }

        [HttpPost]
        [Route("/Events/Delete/")]
        public IActionResult Delete(int[] eventIds)
        {
            //one or several ids and find the related event object and remove it from data source
            foreach (int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);

            }

            context.SaveChanges();
            return Redirect("/Events"); // return to homepage once Id is removed
        }

        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //ViewBag.eventToEdit = EventData.GetById(eventId);
            ViewBag.eventToEdit = context.Events.Find(eventId);
            ViewBag.title = "Edit Event" + ViewBag.eventToEdit.Name + "(ID:" + ViewBag.eventToEdit.Id
                + ")";
            return View();
        }

        [HttpPost]
        [Route("/events/edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            //ViewBag.eventToEdit = EventData.GetById(eventId);
            ViewBag.eventToEdit = context.Events.Find(eventId);
            ViewBag.eventToEdit.Name = name;
            ViewBag.eventToEdit.Description = description;

            return Redirect("/Events");
        }
    }
}

