using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult NotificationList()
        {
            var notifications = _notificationService.GetAll();
            return View(notifications);
        }



        [HttpPost]
        public IActionResult AddNotification(Notification notification)
        {
            _notificationService.Create(notification);
            return RedirectToAction("NotificationList", "Notification");
        }


        [HttpPost]
        public IActionResult UpdateNotification(Notification notification)
        {
            _notificationService.Update(notification);
            return RedirectToAction("NotificationList", "Notification");
        }

        public IActionResult DeleteNotification(int id)
        {
            _notificationService.Delete(id);
            return RedirectToAction("UserDashboard", "User");
        }
    }
}