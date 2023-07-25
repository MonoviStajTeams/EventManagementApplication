using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Route("NotificationList")]
        public IActionResult NotificationList()
        {
            var notificationList = _notificationService.GetAll();
            return Ok(notificationList);
        }


        [HttpPost]
        [Route("AddNotification")]
        public IActionResult AddNotification(Notification notification)
        {
            _notificationService.Create(notification);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateNotification")]
        public IActionResult UpdateNotification(Notification notification)
        {
            _notificationService.Update(notification);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteNotification{id}")]
        public IActionResult DeleteNotification(int id)
        {
            _notificationService.Delete(id);
            return Ok();
        }
    }
}
