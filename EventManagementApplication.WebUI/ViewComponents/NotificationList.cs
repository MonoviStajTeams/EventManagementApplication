using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class NotificationList : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        public NotificationList(INotificationService notificationService, IUserService userService)
        {
            _notificationService = notificationService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Session.GetString("Email")!;

            var user = _userService.GetByMail(email!);
            var notifications = _notificationService.GetAll().Where(x=>x.ReceivingId == user.Id);
            return View(notifications);

        }
    }
}