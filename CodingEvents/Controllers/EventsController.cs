using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //events will be stored dictonary
       // static private List<Event> Events = new List<Event>();

        // GET: /<controller>/
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

        //POST: /<controller>/Events/Add
        //Route /Events/Add
        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string description) //this method handles form submission
        {
            EventData.Add(new Event(name, description)); 
            return Redirect("/Events"); 
            
        }

    }
}
