using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Core.Aspects.TransactionAspects;
using EventManagementApplication.Core.Aspects.ValidationAspects;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Concrete
{

    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [FluentValidateAspect(typeof(NotificationValidator))]
        public void Create(Notification entity)
        {

            _unitOfWork.Notifications.Add(entity);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var notification = _unitOfWork.Notifications.GetById(id);
            if (notification != null)
            {
                _unitOfWork.Notifications.Remove(notification);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<Notification> GetAll()
        {
            return _unitOfWork.Notifications.GetAll();
        }

        public Notification GetById(int id)
        {
            return _unitOfWork.Notifications.GetById(id);
        }

        [FluentValidateAspect(typeof(NotificationValidator))]
        public void Update(Notification entity)
        {
            _unitOfWork.Notifications.Update(entity);
            _unitOfWork.Save();
        }

        public void SendInvitationNotification(Invitation invitation, User user)
        {

            var notification = new Notification
            {
                InvitationId = invitation.Id,
                Invitation = invitation,
                ReceivingId = user.Id,
                User = user,

            };

            _unitOfWork.Notifications.Add(notification);
            _unitOfWork.Save();

        }

        public void SendReminderNotifications()
        {
            DateTime reminderTime = DateTime.Now.AddHours(2);

            var events = _unitOfWork.Events.GetAll()
                .Where(e => e.Date > DateTime.Now && e.Date < reminderTime)
                .ToList();

            foreach (var ev in events)
            {
                var invitations = _unitOfWork.Invitations.GetAll()
                    .Where(i => i.EventId == ev.Id)
                    .ToList();

                var acceptedUsers = _unitOfWork.UserInvitationMappings.GetAll()
                    .Where(m => invitations.Any(i => i.Id == m.InvitationId) && m.Status == true)
                    .Select(m => m.User)
                    .ToList();

                foreach (var user in acceptedUsers)
                {
                    SendInvitationReminder(ev, user);
                }
            }
        }

        private void SendInvitationReminder(Event ev, User user)
        {
            var invitation = _unitOfWork.Invitations.GetAll()
                .FirstOrDefault(i => i.EventId == ev.Id && i.UserId == user.Id);

            if (invitation != null)
            {
                var notification = new Notification
                {
                    InvitationId = invitation.Id,
                    Invitation = invitation,
                    ReceivingId = user.Id,
                    User = user,
                };

                _unitOfWork.Notifications.Add(notification);
                _unitOfWork.Save();

                SendNotificationToUserByMail(user, GetReminderNotificationContent(ev));
            }
        }

        private string GetReminderNotificationContent(Event ev)
        {
            return $"Etkinlik: {ev.Title}\n" +
                   $"Tarih: {ev.Date}\n" +
                   $"Saat: {ev.StartTime}\n" +
                   $"Etkinlik 2 saat içinde baþlayacak.";
        }

        private void SendNotificationToUserByMail(User user, string notificationContent)
        {
            // Bildirim gönderme iþlemi burada mail ile yapýlabilir hem uygulama için hemde mail ile olmuþ olur
        }




    }
}
