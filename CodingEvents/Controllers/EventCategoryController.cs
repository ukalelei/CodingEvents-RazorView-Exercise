using System;
using System.Collections.Generic;
using System.Linq;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Pass DbContext category values as a list into the view template as a model
            List<EventCategory> categories = context.EventCategories.ToList();
            return View(categories);
        }

       

    }
}
