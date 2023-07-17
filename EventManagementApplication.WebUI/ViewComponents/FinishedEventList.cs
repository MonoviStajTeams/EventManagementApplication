using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class FinishedEventList : ViewComponent
    {
        private readonly IEventService _eventService;

        public FinishedEventList(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IViewComponentResult Invoke()
        {
            var eventList = _eventService.GetAll().Where(e => !e.Status);
            return View(eventList);
        }
    }
}