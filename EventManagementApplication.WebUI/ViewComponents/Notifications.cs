using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class Notifications : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public Notifications
            (INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var notifications = _notificationService.GetAll();
            return View(notifications);
        }
    }
}