using System;
using System.Collections.Generic;
using System.Linq;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
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

    }


}
