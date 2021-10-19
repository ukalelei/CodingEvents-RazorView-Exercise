using System;
using System.Collections.Generic;
using System.Linq;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class TagController : Controller
    {
        //makes instance variable available to controller
        private EventDbContext context;
        public TagController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Pass DbContext category values as a list into the view template as a model
            List<Tag> tags = context.Tags.ToList();
            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //Pass a new instance
            AddTagViewModel addTagViewModel = new AddTagViewModel();
            return View(addTagViewModel);
        }

        [HttpPost]
        [Route("/Tag/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddTagViewModel addTagViewModel)
        {
            if (ModelState.IsValid)
            {
                Tag newTag = new Tag
                {
                    Name = addTagViewModel.Name
                };

                context.Tags.Add(newTag); //add to database if form input meets the validation conditions
                context.SaveChanges(); //save changes to database
                return Redirect("/Tag");
            }
            return View("Create", addTagViewModel);
        }

        [HttpGet]// responds to URLs like /Tag/AddEvent/5 (where 5 is an event ID)
        public IActionResult AddEvent(int id) 
        {
            Event theEvent = context.Events.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();
            AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel viewModel) //takes in a AddEventTagViewModel object which will be created via model binding.
        {
            if (ModelState.IsValid)
            {

                int eventId = viewModel.EventId;
                int tagId = viewModel.TagId;

                List<EventTag> existingItems = context.EventTags // query for existing EventTag objects that have the some EventId/TagId pair
                   .Where(et => et.EventId == eventId)
                   .Where(et => et.TagId == tagId)
                   .ToList();

                if (existingItems.Count == 0) //create and save a new EventTag object is skipped if event already has the tag
                {
                    EventTag eventTag = new EventTag
                    {
                        EventId = eventId,
                        TagId = tagId
                    };
                    context.EventTags.Add(eventTag);
                    context.SaveChanges(); //if validation pass, save new EventTag object to database
                }
                return Redirect("/Events/Detail/" + eventId);
            }

            return View(viewModel);
        }

    }
}
