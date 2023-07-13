using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
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

    }
}
