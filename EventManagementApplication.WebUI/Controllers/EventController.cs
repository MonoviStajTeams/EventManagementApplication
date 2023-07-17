﻿using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(Event entity)
        {
            _eventService.Create(entity);
            return RedirectToAction("Index","Event");
        }

        [HttpGet]
        public IActionResult UpdateEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateEvent(Event entity)
        {
            _eventService.Update(entity);
            return RedirectToAction("Index", "Event");
        }

     
        public IActionResult DeleteEvent(int id)
        {
            _eventService.Delete(id);
            return RedirectToAction("Index", "Event");
        }
    }
}
