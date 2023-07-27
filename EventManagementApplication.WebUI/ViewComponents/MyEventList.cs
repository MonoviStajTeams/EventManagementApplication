using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class MyEventList : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        public MyEventList(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {

            string email = HttpContext.Session.GetString("Email")!;

            var user = _userService.GetByMail(email!);
            var myEventList = _eventService.GetAll().Where(x=>x.UserId == user.Id);
            return View(myEventList);
        }
    }
}
