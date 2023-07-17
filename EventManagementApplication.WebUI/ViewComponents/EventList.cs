using EventManagementApplication.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class EventList:ViewComponent
    {
        private readonly IEventService _eventService;

        public EventList(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IViewComponentResult Invoke()
        {
            var eventList = _eventService.GetAll();
            return View(eventList);
        }
    }
}
