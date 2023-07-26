using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class MyEvents : ViewComponent
    {
        private readonly IEventService _eventService;

        public MyEvents(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IEnumerable<Event> GetAllByUserId(int id)
        {
            return _unitOfWork.Events.GetAllWithIncludes(x => x.User).Where(x => x.UserId == id);

        }
    }
}
