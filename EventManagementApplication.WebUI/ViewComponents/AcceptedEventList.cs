using EventManagementApplication.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class AcceptedEventList:ViewComponent
    {
        private readonly IEventService _eventService;

        public AcceptedEventList(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IViewComponentResult Invoke() 
        {
            var events = _eventService.GetAll().Take(2);
            return View(events); 
        }
    }
}
