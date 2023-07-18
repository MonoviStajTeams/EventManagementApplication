using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class NotificationList : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public NotificationList (INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            //var notifications = _notificationService.GetAll();
            //return View(notifications);
            return View();
        }
    }
}