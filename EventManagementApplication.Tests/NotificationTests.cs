using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EventManagementApplication.Tests
{
    public class NotificationTests
    {

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Notification_validaiton_check()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<INotificationRepository> mockNotificationRepository = new Mock<INotificationRepository>();

            NotificationService notificationService = new NotificationService(mockUnitOfWork.Object);

            notificationService.Create(new Notification());
        }
    }
}