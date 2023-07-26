using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class FinishedEventList : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        public FinishedEventList(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Session.GetString("Email")!;

            var user = _userService.GetByMail(email!);
            var events = _eventService.GetAll().Where(x=>x.UserId == user.Id).Where(e => e.Status == false).ToList();
            return View(events);
        }
    }
}
