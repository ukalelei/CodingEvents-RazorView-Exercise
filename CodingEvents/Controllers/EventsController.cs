using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //events will be stored in the empty list 
        static private List<string> Events = new List<string>();

        // GET: /<controller>/Events
        [HttpGet] //index only respond to get request
        public IActionResult Index()
        {
            //add events to empty list
            /* this is not needed anymore since we already a New event action method line 48 that adds event
             *  Events.Add("Strange Loop");
                Events.Add("Grace Hopper");
                Events.Add("Code with Pride");*/ 

            //to access events list in a view, events are added to a property name "event" in viewbag
            //viewbag: carries variables from the controller into the view
            ViewBag.events = Events; //events is added to viewbag

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
        public IActionResult NewEvent(string name) //this method handles form submission
        {
            Events.Add(name); //user input get add to event list 
            return Redirect("/Events"); //Redirect user to Index.
                                        //Redirect send user to different page after submitting form.
            
        }

    }
}
