using EventManagementApplication.Business.Abstract;
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
            var events = _eventService.GetAll().Where(e => e.Status == false).ToList();
            return View(events);
        }
    }
}
