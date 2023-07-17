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

        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Notification notification)
        {
            _notificationService.Create(notification);
            return RedirectToAction("Index", "Notification");
        }

        [HttpGet]
        public IActionResult UpdateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateRole(Notification notification)
        {
            _notificationService.Create(notification);
            return RedirectToAction("Index", "Notification");
        }

        public IActionResult DeleteRole(int id)
        {
            _notificationService.Delete(id);
            return RedirectToAction("Index", "Notification");
        }
    }
}
