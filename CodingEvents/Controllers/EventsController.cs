using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Models;
using CodingEvents.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        // GET: /<controller>/
        [HttpGet] //index only respond to get request
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll(); //events is added to viewbag

            return View();
        }

        //GET: /<controller>/Events/Add
        [HttpGet]
        public IActionResult Add()//If the action attribute in the <form> tag leads to the same route as the form is being rendered at, you do not have to include an action attribute.
        {
            return View(); //Add.cshtml
        }

        //POST: /<controller>/
        //Route /Events/Add
        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent) //model instance is created on form submission
        {

            EventData.Add(newEvent); 
            return Redirect("/Events");             
        }

        //action method to return a view designed to delete events.
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/Events/Delete")]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events"); // return to homepage once Id is removed
        }

    }
}
