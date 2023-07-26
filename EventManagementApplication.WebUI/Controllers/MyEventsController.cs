using Microsoft.AspNetCore.Mvc;
using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
namespace EventManagementApplication.WebUI.Controllers
{
    public class MyEventsController
    {
        private readonly IEventService _eventService;

        public MyEventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index(int userId)
        {
            var myEvents = GetAllByUserId(userId);
            return View(myEvents);
        }

        public IActionResult Details(int id)
        {
            var myEvent = _eventService.GetById(id);
            if (myEvent == null)
            {
                return NotFound();
            }

            return View(myEvent);
        }

        public IActionResult Create()
        {
            // Implement the logic for creating a new event
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event myEvent)
        {
            if (ModelState.IsValid)
            {
                // Implement the logic for saving the new event
                _eventService.Add(myEvent);
                return RedirectToAction(nameof(Index));
            }

            return View(myEvent);
        }

        public IActionResult Edit(int id)
        {
            var myEvent = _eventService.GetById(id);
            if (myEvent == null)
            {
                return NotFound();
            }

            return View(myEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Event myEvent)
        {
            if (id != myEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Implement the logic for updating the event
                _eventService.Update(myEvent);
                return RedirectToAction(nameof(Index));
            }

            return View(myEvent);
        }

        public IActionResult Delete(int id)
        {
            var myEvent = _eventService.GetById(id);
            if (myEvent == null)
            {
                return NotFound();
            }

            return View(myEvent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Implement the logic for deleting the event
            _eventService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<Event> GetAllByUserId(int id)
        {
            return _eventService.GetAllByUserId(id);
        }

    }
}
