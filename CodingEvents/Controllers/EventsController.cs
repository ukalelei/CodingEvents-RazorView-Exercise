using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models; //even codingevents model in order to use type Event
using CodingEventsDemo.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/Events
        [HttpGet] //index only respond to get request
        public IActionResult Index()
        {

            //to access events list in a view, events are added to a property name "event" in viewbag
            //viewbag: carries variables from the controller into the view
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
        public IActionResult NewEvent(string name, string description) //this method handles form submission
        {
            EventData.Add(new Event(name, description)); //user input get add to event list 
            return Redirect("/Events"); //Redirect user to Index.
                                        //Redirect send user to different page after submitting form.
            
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
