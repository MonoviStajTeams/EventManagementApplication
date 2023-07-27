using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApplication.WebUI.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var eventList = _eventService.GetAll();
            return View(eventList);
        }

        public IActionResult Pagination(int page)
        {
            return ViewComponent("EventList", new { page });
        }

        public IActionResult EventSingle(int id)
        {
            var eventById = _eventService.GetById(id);
            return View(eventById);
        }


        [HttpGet]
        public IActionResult AddEvent()
        {
            var typeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "option1", Text = "Option 1" },
                new SelectListItem { Value = "option2", Text = "Option 2" },
                new SelectListItem { Value = "option3", Text = "Option 3" }
            };

            // ViewBag içinde TypeList'i ekleyin.
            ViewBag.TypeList = new SelectList(typeList, "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(Event entity)
        {
            _eventService.Create(entity);
            return RedirectToAction("Index", "Event");
        }



        [HttpGet]
        public IActionResult UpdateEventUser(int id)
        {
            var events = _eventService.GetById(id);
            var typeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "option1", Text = "Option 1" },
                new SelectListItem { Value = "option2", Text = "Option 2" },
                new SelectListItem { Value = "option3", Text = "Option 3" }
            };

            // ViewBag içinde TypeList'i ekleyin.
            ViewBag.TypeList = new SelectList(typeList, "Value", "Text");

            return View(events);
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

        public IActionResult GetInactiveEventsByUserId(int id)
        {
            var eventList = _eventService.GetInactiveEventsByUserId(id);
            return View(eventList);
        }

        public IActionResult AcceptedEventViewUser()
        {
            return View();
        }

        public IActionResult FinishedEventViewUser()
        {
            return View();
        }

        public IActionResult MyEventViewUser()
        {
            return View();
        }

    }
}
