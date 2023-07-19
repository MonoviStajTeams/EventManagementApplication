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

        public IViewComponentResult Invoke(int page)
        {

            int pageSize = 8; // Her sayfada gösterilecek blog sayısı
            var eventList = _eventService.GetAll().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return View(eventList);
        }
    }
}
