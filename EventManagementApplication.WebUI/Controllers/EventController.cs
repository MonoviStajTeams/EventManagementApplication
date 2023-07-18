﻿using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
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
            var eventList = _eventService.GetAll();
            return View(eventList);
        }

     
        public IActionResult EventSingle(int id)
        {
            var eventById = _eventService.GetById(id);
            return View(eventById);
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
        public IActionResult UpdateEventUser(int id)
        {
            var events = _eventService.GetById(id);
            return View(events);
        }

        [HttpGet]
        public IActionResult UpdateEventAdmin(int id)
        {
            var events = _eventService.GetById(id);
            return View(events);
        }

        [HttpPost]
        public IActionResult UpdateEvent(Event entity)
        {
            //User ıd si gönderilecektir 
            _eventService.Update(entity);
            return RedirectToAction("Index", "Event");
        }

     
        public IActionResult DeleteEvent(int id)
        {
            _eventService.Delete(id);
            return RedirectToAction("Index", "Event");
        }

        public IActionResult GetInactiveEventsByUserId(int id)
        {
            var eventList = _eventService.GetInactiveEventsByUserId(id);
            return View(eventList);
        }

    
    }
}
