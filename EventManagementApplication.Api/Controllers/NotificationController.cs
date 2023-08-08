using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Entities.dtos;
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
        [Route("GetAll")]
        public IActionResult NotificationList()
        {
            var notificationList = _notificationService.GetAll();
            return Ok(notificationList);
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult AddNotification(Notification notification)
        {
            _notificationService.Create(notification);
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateNotification(Notification notification)
        {
            _notificationService.Update(notification);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            _notificationService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("SendInvitationNotification")]
        public IActionResult SendInvitationNotification([FromBody] InvitationUserModel model)
        {
            if (model == null || model.Invitation == null || model.User == null)
            {
                return BadRequest("Invitation and user data must be provided.");
            }

            _notificationService.SendInvitationNotification(model.Invitation, model.User);
            return Ok();
        }


        [HttpGet]
        [Route("SendReminderNotifications")]
        public IActionResult SendReminderNotifications()
        {
            _notificationService.SendReminderNotifications();
            return Ok();
        }
    }
}
